using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Emsi.Playground
{
    public class Program
    {
        private static IConfigurationRoot Configuration { get; set; }

        public static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true)
                .AddUserSecrets<Program>();

            Configuration = builder.Build();

            await GetDataAsync();
        }

        private static async Task GetDataAsync()
        {
            var skillEndpoint = "https://emsiservices.com/skills";

            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken());

            var response = await client.GetStringAsync($"{skillEndpoint}/status");

            Console.WriteLine(response);
        }

        private static string GetToken()
        {
            return Configuration["EmsiSettings:AccessToken"];
        }
    }
}
