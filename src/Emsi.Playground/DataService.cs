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
        }
    }
}
