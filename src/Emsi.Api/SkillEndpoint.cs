using Emsi.Api.Dtos;
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

        public Task<VersionsDto?> GetVersionsAsync()
            => _client.GetAsync<VersionsDto>($"{Endpoint}/versions");

        public Task<VersionMetaDataDto?> GetVersionsMetaDataAsync(string version)
            => _client.GetAsync<VersionMetaDataDto>($"{Endpoint}/versions/{version}");

        public Task<VersionChangesDto?> GetVersionChangesAsync(string version)
            => _client.GetAsync<VersionChangesDto>($"{Endpoint}/versions/{version}/changes");

        public Task<RelatedSkillsDto?> GetRelatedSkillsAsync(string version, RequestIdsDto ids)
            => _client.PostAsync<RelatedSkillsDto>($"{Endpoint}/versions/{version}/related", ids);

        public Task<SourceTracingDto?> GetExtractSkillsSourceTracing(string version, RequestSourceTraceDto text)
            => _client.PostAsync<SourceTracingDto>($"{Endpoint}/versions/{version}/extract/trace", text);

    }
}
