using Emsi.Api;
using System;
using System.Threading.Tasks;

namespace Emsi.Playground
{
    public class DataService
    {
        private readonly EmsiClient _emsiClient;

        public DataService(EmsiClient emsiClient)
        {
            _emsiClient = emsiClient;
        }

        public async Task RunAsync()
        {
            //var responseDto = await _emsiClient.Skills.GetStatusAsync();

            //if (!responseDto.IsSuccess)
            //{
            //    responseDto.Error.Message
            //}

            var statusDto = await _emsiClient.Skills.GetStatusAsync();

            if (statusDto is not null)
            {
                Console.WriteLine(statusDto.Data.Healthy);
                Console.WriteLine(statusDto.Data.Message);
            }

            var metaDto = await _emsiClient.Skills.GetMetaAsync();

            if (metaDto is not null)
            {
                Console.WriteLine(metaDto.Data.Attribution.Title);
                Console.WriteLine(metaDto.Data.Attribution.Body);
                Console.WriteLine(metaDto.Data.LatestVersion);
            }

            var versionDto = await _emsiClient.Skills.GetVersionsAsync();


            if (versionDto is not null)
            {
                foreach (var data in versionDto.Data)
                {
                    Console.WriteLine(data);
                }
            }

            var r = new Random();

            var version = versionDto?.Data[r.Next(versionDto.Data.Count)];

            if (version is not null)
            {
                var versionMetaDataDto = await _emsiClient.Skills.GetVersionsMetaDataAsync(version);

                if (versionMetaDataDto is not null)
                {
                    foreach (var field in versionMetaDataDto.Data.Fields)
                    {
                        Console.WriteLine(field);
                    }

                    Console.WriteLine($"RemovedSkillsCount:  {versionMetaDataDto.Data.RemovedSkillCount}");

                    Console.WriteLine($"SkillsCount: {versionMetaDataDto.Data.SkillCount}");

                    Console.WriteLine("Types: ");

                    foreach (var skill in versionMetaDataDto.Data.Types)
                    {
                        Console.WriteLine($"Description: {skill.Description}");
                        Console.WriteLine($"Id: {skill.Id}");
                        Console.WriteLine($"Name: {skill.Name}");
                    }
                }

                var versionChangesDto = await _emsiClient.Skills.GetVersionChangesAsync(version);

                if (versionChangesDto is not null)
                {
                    Console.WriteLine("\nAdditions: ");

                    foreach (var addition in versionChangesDto.Data.Additions)
                    {
                        Console.WriteLine(addition.Id);
                        Console.WriteLine(addition.Name);
                        Console.WriteLine(addition.Type);
                    }

                    Console.WriteLine("\nConsolidations: ");

                    foreach (var consolidation in versionChangesDto.Data.Consolidations)
                    {
                        Console.WriteLine(consolidation.IdFrom);
                        Console.WriteLine(consolidation.IdTo);
                        Console.WriteLine(consolidation.NameFrom);
                        Console.WriteLine(consolidation.NameTo);
                    }

                    Console.WriteLine("\nRemovals: ");

                    foreach (var removal in versionChangesDto.Data.Removals)
                    {
                        Console.WriteLine(removal.Id);
                        Console.WriteLine(removal.Name);
                    }

                    Console.WriteLine("\nRenames: ");

                    foreach (var rename in versionChangesDto.Data.Renames)
                    {
                        Console.WriteLine(rename.Id);
                        Console.WriteLine(rename.NewName);
                        Console.WriteLine(rename.OldName);
                    }

                    Console.WriteLine("\nTaggingImprovements: ");

                    foreach (var taggingImprovement in versionChangesDto.Data.TaggingImprovements)
                    {
                        Console.WriteLine(taggingImprovement.Id);
                        Console.WriteLine(taggingImprovement.Name);
                    }

                    Console.WriteLine("\nTypeChanges: ");

                    foreach (var typeChange in versionChangesDto.Data.TypeChanges)
                    {
                        Console.WriteLine(typeChange.Id);
                        Console.WriteLine(typeChange.Name);
                        Console.WriteLine(typeChange.NewType);
                        Console.WriteLine(typeChange.OldType);
                    }
                }

                //List<string> ids = new List<string> { "KS1200364C9C1LK3V5Q1", "KS1275N74XZ574T7N47D", "KS125QD6K0QLLKCTPJQ0" };
                //_emsiClient.Skills.GetRelatedSkillsAsync(version, ids);

            }


        }
    }
}
