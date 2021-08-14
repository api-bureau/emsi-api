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

            string version = "latest";
            string queryparams = "q=.NET&typeIds=ST1,ST2&fields=id,name,type,infoUrl&limit=5";

            var skillsDto = await _emsiClient.Skills.GetSkillsAsync(version, queryparams);

            if (skillsDto is not null)
            {
                Console.WriteLine("\nList of all Skills:");

                foreach (var attr in skillsDto.Attributions)
                {
                    Console.WriteLine(attr.Name);
                    Console.WriteLine(attr.Text);
                }

                foreach (var data in skillsDto.Data)
                {
                    Console.WriteLine(data.Id);
                    Console.WriteLine(data.InfoUrl);
                    Console.WriteLine(data.Name);
                    Console.WriteLine(data.Type.Id);
                    Console.WriteLine(data.Type.Name);
                }
            }

            string id = "KS124JB619VXG6RQ810C";
            var skillIdDto = await _emsiClient.Skills.GetSkillbyIDAsync(version, id);

            if (skillIdDto is not null)
            {
                Console.WriteLine("\n Skill by ID:");

                foreach (var attr in skillIdDto.Attributions)
                {
                    Console.WriteLine(attr.Name);
                    Console.WriteLine(attr.Text);
                }

                Console.WriteLine(skillIdDto.Data.Id);
                Console.WriteLine(skillIdDto.Data.InfoUrl);
                Console.WriteLine(skillIdDto.Data.Name);
                Console.WriteLine(skillIdDto.Data.RemovedDescription);

                foreach (var tag in skillIdDto.Data.Tags)
                {
                    Console.WriteLine(tag.Key);
                    Console.WriteLine(tag.Value);
                }

                Console.WriteLine(skillIdDto.Data.Type.Id);
                Console.WriteLine(skillIdDto.Data.Type.Name);
            }

            var request = new RequestDto
            {
                ids = new[] { "KS1200364C9C1LK3V5Q1", "KS1275N74XZ574T7N47D", "KS125QD6K0QLLKCTPJQ0" }
            };

            string queryParams = "typeIds=ST1,ST2&fields=id,name,type,infoUrl";

            var skillDto = await _emsiClient.Skills.GetSkillAsync(version, request, queryParams);

            if (skillDto is not null)
            {
                Console.WriteLine("\nList of Requested Skills:");

                foreach (var attr in skillDto.Attributions)
                {
                    Console.WriteLine(attr.Name);
                    Console.WriteLine(attr.Text);
                }

                foreach (var data in skillDto.Data)
                {
                    Console.WriteLine(data.Id);
                    Console.WriteLine(data.InfoUrl);
                    Console.WriteLine(data.Name);
                    Console.WriteLine(data.Type.Id);
                    Console.WriteLine(data.Type.Name);
                }
            }

            var reqData = new RequestDocumentDto
            {
                text = "... Great candidates also have\n\n Experience with a particular JS MV* framework (we happen to use React)\n Experience working with databases\n Experience with AWS\n Familiarity with microservice architecture\n Familiarity with modern CSS practices, e.g. LESS, SASS, CSS-in-JS ...",
                confidenceThreshold = 0.6
            };

            var skillDocDto = await _emsiClient.Skills.GetSkillFromDocumentAsync(version, reqData);

            if (skillDocDto is not null)
            {
                Console.WriteLine("\nExtracted Skills:");

                foreach (var attr in skillDocDto.Attributions)
                {
                    Console.WriteLine(attr.Name);
                    Console.WriteLine(attr.Text);
                }

                foreach (var data in skillDocDto.Data)
                {
                    Console.WriteLine(data.Confidence);
                    Console.WriteLine(data.Skill.Id);
                    Console.WriteLine(data.Skill.InfoUrl);
                    Console.WriteLine(data.Skill.Name);

                    foreach (var tag in data.Skill.Tags)
                    {
                        Console.WriteLine(tag.Key);
                        Console.WriteLine(tag.Value);
                    }

                    Console.WriteLine(data.Skill.Type.Id);
                    Console.WriteLine(data.Skill.Type.Name);
                }
            }
        }
    }
}
