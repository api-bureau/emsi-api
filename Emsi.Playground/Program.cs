using Emsi.Playground.Dtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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

        public List<string> skillsVersions = new List<string> { "7.47", "7.46", "7.45", "7.44", "7.43", "7.42", "7.41", "7.40", "7.39", "7.38", "7.37", "7.36", "7.35", "7.34", "7.33", "7.32", "7.31", "7.30", "7.29", "7.28", "7.27", "7.26", "7.25", "7.24", "7.23", "7.22", "7.21", "7.20", "7.19", "7.18", "7.17", "7.16", "7.15", "7.14", "7.13", "7.12", "7.11", "7.10", "7.9", "7.8", "7.7", "7.6", "7.5", "7.4", "7.3", "7.2", "7.1", "7.0", "6.16", "6.15", "6.14", "6.13", "6.12", "6.1", "6.10", "6.9", "6.8", "6.7", "6.6", "6.5", "6.4", "6.3", "6.2", "6.1", "6.0", "5.1" };

        public static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true)
                .AddUserSecrets<Program>();

            Configuration = builder.Build();


            var SkillsObject = new Program();
            var r = new Random();
            string SkillVersion = SkillsObject.skillsVersions[r.Next(SkillsObject.skillsVersions.Count)];

            await GetStatusAsync();
            await GetMetaAsync();
            await GetAllVersionsAsync();
            await GetSpecificVersionMetadataAsync(SkillVersion);
            await GetVersionChangesAsync(SkillVersion);


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

        //GetVersionsAsync()
        private static async Task GetAllVersionsAsync()
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken());

            DataDto? dto;

            try
            {
                dto = await client.GetFromJsonAsync<DataDto>($"{GetBaseUrl()}/skills/versions");
            }

            catch (Exception e)
            {
                Console.WriteLine($"My message: {e.Message}");
                throw;
            }

            if (dto is not null)
            {
                Console.WriteLine("\nList of all available versions:");

                foreach (var version in dto.Data)
                {
                    Console.WriteLine(version);

                }
            }
        }

        //GetVersionAsync(string version)
        private static async Task GetSpecificVersionMetadataAsync(string version)
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken());

            VersionMetaDataDto? dto;

            try
            {
                dto = await client.GetFromJsonAsync<VersionMetaDataDto>($"{GetBaseUrl()}/skills/versions/{version}");
            }

            catch (Exception e)
            {
                Console.WriteLine($"My message: {e.Message}");
                throw;
            }

            if (dto is not null)
            {
                Console.WriteLine("\nList of fields available:");

                foreach (var field in dto.Data.Fields)
                {
                    Console.WriteLine(field);
                }

                Console.WriteLine($"RemovedSkillsCount:  {dto.Data.RemovedSkillCount}");

                Console.WriteLine($"SkillsCount: {dto.Data.SkillCount}");

                Console.WriteLine("Types: ");

                foreach (var skill in dto.Data.Types)
                {
                    Console.WriteLine($"Description: {skill.Description}");
                    Console.WriteLine($"Id: {skill.Id}");
                    Console.WriteLine($"Name: {skill.Name}");
                }
            }
        }

        //GetChangesAsync(string version)
        private static async Task GetVersionChangesAsync(string version)
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken());

            VersionChangesDto? dto;

            try
            {
                dto = await client.GetFromJsonAsync<VersionChangesDto>($"{GetBaseUrl()}/skills/versions/{version}/changes");
            }

            catch (Exception e)
            {
                Console.WriteLine($"My message: {e.Message}");
                throw;
            }

        

            if (dto is not null)
            {
                Console.WriteLine("\nAdditions: ");

                foreach (var addition in dto.Data.Additions)
                {
                    Console.WriteLine(addition.Id);
                    Console.WriteLine(addition.Name);
                    Console.WriteLine(addition.Type);
                }

                Console.WriteLine("\nConsolidations: ");

                foreach (var consolidation in dto.Data.Consolidations)
                {
                    Console.WriteLine(consolidation.IdFrom);
                    Console.WriteLine(consolidation.IdTo);
                    Console.WriteLine(consolidation.NameFrom);
                    Console.WriteLine(consolidation.NameTo);
                }

                Console.WriteLine("\nRemovals: ");

                foreach (var removal in dto.Data.Removals)
                {
                    Console.WriteLine(removal.Id);
                    Console.WriteLine(removal.Name);
                }

                Console.WriteLine("\nRenames: ");

                foreach (var rename in dto.Data.Renames)
                {
                    Console.WriteLine(rename.Id);
                    Console.WriteLine(rename.NewName);
                    Console.WriteLine(rename.OldName);
                }

                Console.WriteLine("\nTaggingImprovements: ");

                foreach (var taggingImprovement in dto.Data.TaggingImprovements)
                {
                    Console.WriteLine(taggingImprovement.Id);
                    Console.WriteLine(taggingImprovement.Name);
                }

                Console.WriteLine("\nTypeChanges: ");

                foreach (var typeChange in dto.Data.TypeChanges)
                {
                    Console.WriteLine(typeChange.Id);
                    Console.WriteLine(typeChange.Name);
                    Console.WriteLine(typeChange.NewType);
                    Console.WriteLine(typeChange.OldType);
                }
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
