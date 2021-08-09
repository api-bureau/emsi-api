using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Emsi.Playground
{
    // Startup.cs 
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
                .AddUserSecrets<Program>()
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            var emsiClient = new EmsiClient(Configuration, new HttpClient());

            var statusDto = await emsiClient.Skills.GetStatusAsync();

            if (statusDto is not null)
            {
                Console.WriteLine(statusDto.Data.Healthy);
                Console.WriteLine(statusDto.Data.Message);
            }

            var metaDto = await emsiClient.Skills.GetMetaAsync();

            if (metaDto is not null)
            {
                Console.WriteLine(metaDto.Data.Attribution.Title);
                Console.WriteLine(metaDto.Data.Attribution.Body);
                Console.WriteLine(metaDto.Data.LatestVersion);
            }
        }
    }
}
