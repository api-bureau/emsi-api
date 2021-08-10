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
            //var emsiClient = new EmsiClient(Configuration, new HttpClient());

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
        }
    }
}
