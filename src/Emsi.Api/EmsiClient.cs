using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settings.AccessToken);

            Skills = new SkillEndpoint(this);
        }

        public async Task AuthenticateAsync()
        {
            var response = await _client.PostAsync(_settings.AuthorisationUrl, new FormUrlEncodedContent(new List<KeyValuePair<string?, string?>>
                    {
                        new KeyValuePair<string?, string?>("client_id", _settings.ClientId),
                        new KeyValuePair<string?, string?>("client_secret", _settings.ClientSecret),
                        new KeyValuePair<string?, string?>("grant_type", "client_credentials"),
                        new KeyValuePair<string?, string?>("scope", _settings.Scope),
                    }));
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

        private async Task CheckConnectionAsync()
        {
            if (_accessToken == null)
            {
                await AuthenticateAsync();
            }
        }
    }
}
