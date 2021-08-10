using Emsi.Api.Dtos;
using System.Threading.Tasks;

namespace Emsi.Api
{
    public class SkillEndpoint
    {
        private const string Endpoint = "/skills";
        private readonly EmsiClient _client;

        public SkillEndpoint(EmsiClient client) => _client = client;

        public Task<StatusDto?> GetStatusAsync()
            => _client.GetAsync<StatusDto>($"{Endpoint}/status");

        public Task<MetaDto?> GetMetaAsync()
            => _client.GetAsync<MetaDto>($"{Endpoint}/meta");
    }
}
