using Emsi.Playground.Dtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Emsi.Playground
{
    public class Program
    {
        private static IConfigurationRoot Configuration { get; set; }

        private static JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true)
                .AddUserSecrets<Program>();

            Configuration = builder.Build();

            await GetStatusAsync();
            await GetMetaAsync();
        }

        private static async Task GetStatusAsync()
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken());

            StatusDto? dto;

            try
            {
                dto = await client.GetFromJsonAsync<StatusDto>($"{GetBaseUrl()}/skills/status");
            }
            catch (Exception e)
            {
                Console.WriteLine($"My message: {e.Message}");
                throw;
            }

            if (dto is not null)
            {
                Console.WriteLine(dto.Data.Healthy);
                Console.WriteLine(dto.Data.Message);
            }
        }

        private static async Task GetMetaAsync()
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken());

            MetaDto? dto;

            try
            {
                dto = await client.GetFromJsonAsync<MetaDto>($"{GetBaseUrl()}/skills/meta");
            }
            catch (Exception e)
            {
                Console.WriteLine($"My message: {e.Message}");
                throw;
            }

            if (dto is not null)
            {
                Console.WriteLine(dto.Data.Attribution.Title);
                Console.WriteLine(dto.Data.Attribution.Body);
                Console.WriteLine(dto.Data.LatestVersion);
            }
        }

        private static string GetToken()
        {
            return Configuration["EmsiSettings:AccessToken"];
        }

        private static string GetBaseUrl()
        {
            return Configuration["EmsiSettings:Url"];
        }
    }
}
