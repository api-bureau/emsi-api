using Emsi.Api.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emsi.Api
{
    public class OccupationEndpoint
    {

    }

    public class SkillEndpoint
    {
        private const string Endpoint = "/skills";
        private readonly EmsiClient _client;

        public SkillEndpoint(EmsiClient client) => _client = client;

        public Task<StatusDto?> GetStatusAsync()
            => _client.GetAsync<StatusDto>($"{Endpoint}/status");

        public Task<MetaDto?> GetMetaAsync()
            => _client.GetAsync<MetaDto>($"{Endpoint}/meta");

        public Task<SkillsDto?> GetSkillsAsync(string version, string queryparams)
            => _client.GetAsync<SkillsDto>($"{Endpoint}/versions/{version}/skills?{queryparams}");

        public Task<SkillIdDto?> GetSkillbyIDAsync(string version, string id)
            => _client.GetAsync<SkillIdDto>($"{Endpoint}/versions/{version}/skills/{id}");

        public Task<SkillsDto?> GetSkillAsync(string version, RequestDto ids, string queryparams)
            => _client.PostAsync<SkillsDto>($"{Endpoint}/versions/{version}/skills?{queryparams}", ids);

        public Task<SkillsDocumentDto?> GetSkillFromDocumentAsync(string version, RequestDocumentDto data)
            => _client.PostAsync<SkillsDocumentDto>($"{Endpoint}/versions/{version}/extract", data);
    }
}
