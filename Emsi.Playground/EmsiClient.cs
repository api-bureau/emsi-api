using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Emsi.Playground
{

    public class EmsiClient
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _client;
        private DateTime? _tokenExpireTime;

        public SkillEndpoint Skills { get; set; }

        public EmsiClient(IConfiguration configuration, HttpClient client)
        {
            _configuration = configuration;
            _client = client;
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken());

            Skills = new SkillEndpoint(this);
        }

        public async Task<T?> GetAsync<T>(string endpoint)
        {
            T? dto;

            try
            {
                dto = await _client.GetFromJsonAsync<T>($"{GetBaseUrl()}{endpoint}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"My message: {e.Message}");
                throw;
            }

            return dto;
        }

        private string GetToken()
        {
            return _configuration["EmsiSettings:AccessToken"];
        }

        private string GetBaseUrl()
        {
            return _configuration["EmsiSettings:Url"];
        }
    }
}
