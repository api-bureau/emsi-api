using Emsi.Api;
using Emsi.Api.Dtos;
using System;
using System.Collections.Generic;
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

                List<string> ids = new List<string> { "KS1200364C9C1LK3V5Q1", "KS1275N74XZ574T7N47D", "KS125QD6K0QLLKCTPJQ0" };

                var request = new RequestIdsDto { Ids = ids };
                var relatedSkillsDto = await _emsiClient.Skills.GetRelatedSkillsAsync(version, request);

                if (relatedSkillsDto is not null)
                {
                    Console.WriteLine("Attributions:");

                    foreach (var attribution in relatedSkillsDto.Attributions)
                    {
                        Console.WriteLine(attribution.Name);
                        Console.WriteLine(attribution.Text);
                    }

                    Console.WriteLine("Datas:");

                    foreach (var data in relatedSkillsDto.Data)
                    {
                        Console.WriteLine($"Id: {data.Id}");
                        Console.WriteLine($"InfoUrl: {data.InfoUrl}");
                        Console.WriteLine($"Name: {data.Name}");
                        Console.WriteLine("Type: ");
                        Console.WriteLine($"Id: {data.Id}");
                        Console.WriteLine($"Name: {data.Name}");
                    }
                }

                var sourceTraceRequest = new RequestSourceTraceDto { text = "... Great candidates also have\n\n Experience with a particular JS MV * framework(we happen to use React)\n Experience working with databases\n Experien*/ce with AWS\n Familiarity with microservice architecture\n Familiarity with modern CSS practices, e.g.LESS, SASS, CSS -in-JS..." };

                var sourceTracingDto = await _emsiClient.Skills.GetExtractSkillsSourceTracing(version, sourceTraceRequest);

                if (sourceTracingDto is not null)
                {
                    Console.WriteLine("Attributions:");
                    foreach (var attribution in sourceTracingDto.Attributions)
                    {
                        Console.WriteLine(attribution.Name);
                        Console.WriteLine(attribution.Text);
                    }

                    Console.WriteLine("Data:");
                    Console.WriteLine($"normalizedText: {sourceTracingDto.Data.NormalizedText}");

                    Console.WriteLine("Skills:");
                    foreach (var skill in sourceTracingDto.Data.Skills)
                    {
                        Console.WriteLine($"confidence: {skill.Confidence}");

                        Console.WriteLine("Skill:");
                        Console.WriteLine($"Id: {skill.Skill.Id}");
                        Console.WriteLine($"InfoUrl: {skill.Skill.InfoUrl}");
                        Console.WriteLine($"Name: {skill.Skill.Name}");
                        Console.WriteLine($"Tags:");
                        foreach (var tag in skill.Skill.Tags)
                        {
                            Console.WriteLine($"Name: {tag.Key}");
                            Console.WriteLine($"Name: {tag.Value}");
                        }
                        Console.WriteLine($"Id: {skill.Skill.Type.Id}");
                        Console.WriteLine($"Name: {skill.Skill.Type.Name}");
                    }

                    Console.WriteLine("Trace:");
                    foreach (var trace in sourceTracingDto.Data.Trace)
                    {
                        Console.WriteLine($"confidence: {trace.ClassificationData}");
                        Console.WriteLine("ContextForms:");
                        foreach (var contextForm in trace.ClassificationData.ContextForms)
                        {
                            Console.WriteLine($"SourceEnd: {contextForm.SourceEnd}");
                            Console.WriteLine($"SourceStart: {contextForm.SourceStart}");
                            Console.WriteLine($"Value: {contextForm.Value}");
                        }

                        Console.WriteLine("Skills:");
                        foreach (var skill in trace.ClassificationData.Skills)
                        {
                            Console.WriteLine($"Confidence: {skill.Confidence}");
                            Console.WriteLine("Skill:");
                            Console.WriteLine($"Id: {skill.Skill.Id}");
                            Console.WriteLine($"InfoUrl: {skill.Skill.InfoUrl}");
                            Console.WriteLine($"Name: {skill.Skill.Name}");
                            Console.WriteLine($"Tags:");
                            foreach (var tag in skill.Skill.Tags)
                            {
                                Console.WriteLine($"Name: {tag.Key}");
                                Console.WriteLine($"Name: {tag.Value}");
                            }
                            Console.WriteLine($"Id: {skill.Skill.Type.Id}");
                            Console.WriteLine($"Name: {skill.Skill.Type.Name}");
                        }
                        Console.WriteLine("SurfaceForm:");
                        Console.WriteLine($"SourceEnd: {trace.SurfaceForm.SourceEnd}");
                        Console.WriteLine($"SourceStart: {trace.SurfaceForm.SourceStart}");
                        Console.WriteLine($"Value: {trace.SurfaceForm.Value}");
                    }

                }
            }
        }
    }
}

