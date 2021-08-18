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

            var responseDto = await _emsiClient.Skills.GetStatusAsync();

            if (responseDto.IsSuccess)
            {
                Console.WriteLine(responseDto.Data!.Healthy);
                Console.WriteLine(responseDto.Data.Message);
            }
            else
            {
                responseDto.Errors.ForEach(e => Console.WriteLine(e.Detail));
            }

            var metaResponseDto = await _emsiClient.Skills.GetMetaAsync();

            if (metaResponseDto.IsSuccess)
            {
                Console.WriteLine(metaResponseDto.Data!.Attribution.Title);
                Console.WriteLine(metaResponseDto.Data.Attribution.Body);
                Console.WriteLine(metaResponseDto.Data.LatestVersion);
            }

            var versions = await _emsiClient.Skills.GetVersionsAsync();

            if (versions.IsSuccess)
            {
                foreach (var data in versions.Data!)
                {
                    Console.WriteLine(data);
                }
            }

            //var r = new Random();

            //var version = versionDto?.Data[r.Next(versionDto.Data.Count)];
            var version = "latest";

            //if (version is not null)
            //{
            var versionMetaDataDto = await _emsiClient.Skills.GetVersionsMetaDataAsync(version);

            if (versionMetaDataDto.IsSuccess)
            {
                foreach (var field in versionMetaDataDto.Data!.Fields)
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
            //}

            var versionChangesResponseDto = await _emsiClient.Skills.GetVersionChangesAsync(version);

            if (versionChangesResponseDto.IsSuccess)
            {
                Console.WriteLine("\nAdditions: ");

                foreach (var addition in versionChangesResponseDto.Data.Additions)
                {
                    Console.WriteLine(addition.Id);
                    Console.WriteLine(addition.Name);
                    Console.WriteLine(addition.Type);
                }

                Console.WriteLine("\nConsolidations: ");

                foreach (var consolidation in versionChangesResponseDto.Data.Consolidations)
                {
                    Console.WriteLine(consolidation.IdFrom);
                    Console.WriteLine(consolidation.IdTo);
                    Console.WriteLine(consolidation.NameFrom);
                    Console.WriteLine(consolidation.NameTo);
                }

                Console.WriteLine("\nRemovals: ");

                foreach (var removal in versionChangesResponseDto.Data.Removals)
                {
                    Console.WriteLine(removal.Id);
                    Console.WriteLine(removal.Name);
                }

                Console.WriteLine("\nRenames: ");

                foreach (var rename in versionChangesResponseDto.Data.Renames)
                {
                    Console.WriteLine(rename.Id);
                    Console.WriteLine(rename.NewName);
                    Console.WriteLine(rename.OldName);
                }

                Console.WriteLine("\nTaggingImprovements: ");

                foreach (var taggingImprovement in versionChangesResponseDto.Data.TaggingImprovements)
                {
                    Console.WriteLine(taggingImprovement.Id);
                    Console.WriteLine(taggingImprovement.Name);
                }

                Console.WriteLine("\nTypeChanges: ");

                foreach (var typeChange in versionChangesResponseDto.Data.TypeChanges)
                {
                    Console.WriteLine(typeChange.Id);
                    Console.WriteLine(typeChange.Name);
                    Console.WriteLine(typeChange.NewType);
                    Console.WriteLine(typeChange.OldType);
                }
            }

            var ids = new List<string> { "KS1200364C9C1LK3V5Q1", "KS1275N74XZ574T7N47D", "KS125QD6K0QLLKCTPJQ0" };

            var requestData = new RequestIdsDto { Ids = ids };
            var relatedSkillsDto = await _emsiClient.Skills.GetRelatedSkillsAsync(version, requestData);

            if (relatedSkillsDto.IsSuccess)
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

            var sourceTraceRequest = new RequestSourceTraceDto { Text = "... Great candidates also have\n\n Experience with a particular JS MV * framework(we happen to use React)\n Experience working with databases\n Experien*/ce with AWS\n Familiarity with microservice architecture\n Familiarity with modern CSS practices, e.g.LESS, SASS, CSS -in-JS..." };

            var sourceTracingDto = await _emsiClient.Skills.ExtractSkillsWithSourceTracingAsync(version, sourceTraceRequest);

            if (sourceTracingDto.IsSuccess)
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
            //}

            string queryparams = "q=.NET&typeIds=ST1,ST2&fields=id,name,type,infoUrl&limit=5";


            var skillsDto = await _emsiClient.Skills.GetSkillsAsync(version, queryparams);

            if (skillsDto.IsSuccess)
            {
                Console.WriteLine("\nList of all Skills:");
                Console.WriteLine("Attributions:");
                foreach (var attr in skillsDto.Attributions)
                {
                    Console.WriteLine($"Name: {attr.Name}");
                    Console.WriteLine($"Text: {attr.Text}");
                }

                Console.WriteLine("Data:");
                foreach (var data in skillsDto.Data)
                {
                    Console.WriteLine($"Id: {data.Id}");
                    Console.WriteLine($"InfoUrl: {data.InfoUrl}");
                    Console.WriteLine($"Name: {data.Name}");
                    Console.WriteLine("Type:");
                    Console.WriteLine($"Id: {data.Type.Id}");
                    Console.WriteLine($"Name: {data.Type.Name}");
                }
            }


            string id = "KS124JB619VXG6RQ810C";

            var skillDto = await _emsiClient.Skills.GetAsync(version, id);

            if (skillDto.IsSuccess)
            {
                var skill = skillDto.Data;

                Console.WriteLine("\n Skill by ID:");
                Console.WriteLine("Attributions: ");

                foreach (var attr in skillDto.Attributions)
                {
                    Console.WriteLine($"Name:{attr.Name}");
                    Console.WriteLine($"Text:{attr.Text}");
                }

                Console.WriteLine("Data:");
                Console.WriteLine($"Id: {skill.Id}");
                Console.WriteLine($"InfoUrl: {skill.InfoUrl}");
                Console.WriteLine($"Name: {skill.Name}");
                Console.WriteLine($"RemovedDescription: {skill.RemovedDescription}");
                Console.WriteLine("Tags: ");

                foreach (var tag in skill.Tags)
                {
                    Console.WriteLine($"Key: {tag.Key}");
                    Console.WriteLine($"Value: {tag.Value}");
                }

                Console.WriteLine("Type:");
                Console.WriteLine($"Id: {skill.Type.Id}");
                Console.WriteLine($"Name: {skill.Type.Name}");
            }

            var request = new RequestIdsDto
            {
                Ids = new[] { "KS1200364C9C1LK3V5Q1", "KS1275N74XZ574T7N47D", "KS125QD6K0QLLKCTPJQ0" }
            };

            string queryParams = "typeIds=ST1,ST2&fields=id,name,type,infoUrl";


            var skillsResponseDto = await _emsiClient.Skills.GetAsync(version, request, queryParams);

            if (skillsResponseDto.IsSuccess)
            {
                Console.WriteLine("\nList of Requested Skills:");
                Console.WriteLine("Attributions: ");

                foreach (var attr in skillsResponseDto.Attributions)
                {
                    Console.WriteLine($"Name:{attr.Name}");
                    Console.WriteLine($"Text:{attr.Text}");
                }

                Console.WriteLine("Data:");

                foreach (var data in skillsResponseDto.Data)
                {
                    Console.WriteLine($"Id: {data.Id}");
                    Console.WriteLine($"InfoUrl: {data.InfoUrl}");
                    Console.WriteLine($"Name: {data.Name}");
                    Console.WriteLine("Type:");
                    Console.WriteLine($"Id: {data.Type.Id}");
                    Console.WriteLine($"Name: {data.Type.Name}");
                }
            }


            //var reqData = new RequestDocumentDto
            //{
            //    Text = "... Great candidates also have\n\n Experience with a particular JS MV* framework (we happen to use React)\n Experience working with databases\n Experience with AWS\n Familiarity with microservice architecture\n Familiarity with modern CSS practices, e.g. LESS, SASS , CSS-in-JS ...",
            //    ConfidenceThreshold = 0.6
            //};


            //var skillDocDto = await _emsiClient.Skills.ExtarctSkillsAsync(version, reqData);

            //if (skillDocDto.IsSuccess)
            //{
            //    Console.WriteLine("\nSkills extracted from document:");
            //    Console.WriteLine("Attributions: ");

            //    foreach (var attr in skillDocDto.Attributions)
            //    {
            //        Console.WriteLine($"Name:{attr.Name}");
            //        Console.WriteLine($"Text:{attr.Text}");
            //    }
            //    Console.WriteLine("Data: ");

            //    foreach (var data in skillDocDto.Data)
            //    {
            //        Console.WriteLine($"Confidence: {data.Confidence}");
            //        Console.WriteLine("Skill: ");

            //        Console.WriteLine($"Id: {data.Skill.Id}");
            //        Console.WriteLine($"InfoUrl: {data.Skill.InfoUrl}");
            //        Console.WriteLine($"Name: {data.Skill.Name}");
            //        Console.WriteLine("Tags: ");

            //        foreach (var tag in data.Skill.Tags)
            //        {
            //            Console.WriteLine($"Key: {tag.Key}");
            //            Console.WriteLine($"Value: {tag.Value}");
            //        }
            //        Console.WriteLine("Type: ");

            //        Console.WriteLine($"Id: {data.Skill.Type.Id}");
            //        Console.WriteLine($"Name: {data.Skill.Type.Name}");
            //    }
            //}

        }
    }
}
