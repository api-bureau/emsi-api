using IdentityModel.Client;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Emsi.Api
{
    public class EmsiClient
    {
        private readonly EmsiSettings _settings;
        private readonly HttpClient _client;
        private string? _accessToken;
        private DateTime? _tokenExpireTime;
        private static JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public SkillEndpoint Skills { get; set; }

        public EmsiClient(IOptions<EmsiSettings> settings, HttpClient client)
        {
            _settings = settings.Value;
            _client = client;

            Skills = new SkillEndpoint(this);
        }

        public async Task AuthenticateAsync()
        {
            var request = new ClientCredentialsTokenRequest
            {
                Address = _settings.AuthorisationUrl,
                ClientId = _settings.ClientId,
                ClientSecret = _settings.ClientSecret,
                Scope = _settings.Scope
            };

            var token = await _client.RequestClientCredentialsTokenAsync(request);

            if (token is null) return;

            _accessToken = token.AccessToken;

            _client.SetBearerToken(_accessToken);
        }

        public async Task<T?> GetAsync<T>(string endpoint)
        {
            await CheckConnectionAsync();

            T? dto;

            try
            {
                dto = await _client.GetFromJsonAsync<T>($"{_settings.BaseUrl}{endpoint}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"My message: {e.Message}");

                //return new ResponseDto { Error = new ErrorDto() };

                throw;
            }

            return dto;
        }

        public async Task<TResponse?> PostAsync<TResponse>(string endpoint, object body)
        {
            await CheckConnectionAsync();

            TResponse? dto;

            try
            {
                var response = await _client.PostAsJsonAsync($"{_settings.BaseUrl}{endpoint}", body);

                dto = await JsonSerializer.DeserializeAsync<TResponse>(await response.Content.ReadAsStreamAsync(), _jsonOptions);
            }
            catch (Exception e)
            {
                Console.WriteLine($"My message: {e.Message}");

                //return new ResponseDto { Error = new ErrorDto() };

                throw;
            }

            return dto;
        }

        private async Task CheckConnectionAsync()
        {
            //ToDo Check Expiry Time

            if (_accessToken == null)
            {
                await AuthenticateAsync();
            }
        }
    }
}
