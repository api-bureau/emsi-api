using IdentityModel.Client;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;

namespace Emsi.Api.Http
{
    public class ApiConnection
    {
        private const string DeseralialisationIssue = "Problem with deserialisation";
        private readonly LightcastSettings _settings;
        private readonly HttpClient _client;
        private string? _accessToken;
        //private DateTime? _tokenExpireTime;
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
        };

        public ApiConnection(HttpClient httpClient, IOptions<LightcastSettings> settings)
        {
            _settings = settings.Value;
            _client = httpClient;
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

        public async Task<ResponseDto<T>> GetAsync<T>(string endpoint)
        {
            await CheckConnectionAsync();

            ResponseDto<T>? dto;

            try
            {
                dto = await _client.GetFromJsonAsync<ResponseDto<T>>($"{_settings.BaseUrl}{endpoint}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"My message: {e.Message}");

                dto = new ResponseDto<T>();

                dto.AddError(e.Message);
            }

            if (dto == null)
            {
                dto = new ResponseDto<T>();

                dto.AddError(DeseralialisationIssue);
            }

            return dto;
        }

        public async Task<ResponseDto<T>> PostAsync<T>(string endpoint, object body)
        {
            await CheckConnectionAsync();

            ResponseDto<T>? dto;

            try
            {
                var response = await _client.PostAsJsonAsync($"{_settings.BaseUrl}{endpoint}", body);

                var content = await response.Content.ReadAsStringAsync();

                dto = await JsonSerializer.DeserializeAsync<ResponseDto<T>>(await response.Content.ReadAsStreamAsync(), _jsonOptions);
            }

            catch (Exception e)
            {
                Console.WriteLine($"My message: {e.Message}");

                dto = new ResponseDto<T>();

                dto.AddError(e.Message);
            }

            if (dto == null)
            {
                dto = new ResponseDto<T>();

                dto.AddError(DeseralialisationIssue);
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
