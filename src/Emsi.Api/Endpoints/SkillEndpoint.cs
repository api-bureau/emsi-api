using Emsi.Api.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emsi.Api.Endpoints
{

    public class SkillEndpoint
    {
        private const string Endpoint = "/skills";
        private readonly EmsiClient _client;

        public SkillEndpoint(EmsiClient client) => _client = client;

        public Task<ResponseDto<StatusDto>> GetStatusAsync()
            => _client.GetAsync<StatusDto>($"{Endpoint}/status");

        public Task<ResponseDto<MetaDto>> GetMetaAsync()
            => _client.GetAsync<MetaDto>($"{Endpoint}/meta");

        //public Task<VersionsDto?> GetVersionsAsync()
        //    => _client.GetAsync<VersionsDto>($"{Endpoint}/versions");

        public Task<ResponseDto<VersionMetadataDto>> GetVersionsMetaDataAsync(string version)
            => _client.GetAsync<VersionMetadataDto>($"{Endpoint}/versions/{version}");

        //public Task<VersionChangesDto?> GetVersionChangesAsync(string version)
        //    => _client.GetAsync<VersionChangesDto>($"{Endpoint}/versions/{version}/changes");

        //public Task<RelatedSkillsDto?> GetRelatedSkillsAsync(string version, RequestIdsDto ids)
        //    => _client.PostAsync<RelatedSkillsDto>($"{Endpoint}/versions/{version}/related", ids);

        //public Task<SourceTracingDto?> GetExtractSkillsSourceTracing(string version, RequestSourceTraceDto text)
        //    => _client.PostAsync<SourceTracingDto>($"{Endpoint}/versions/{version}/extract/trace", text);

        public Task<ResponseDto<List<SkillDto>>> GetSkillsAsync(string version, string queryparams)
            => _client.GetAsync<List<SkillDto>>($"{Endpoint}/versions/{version}/skills?{queryparams}");

        public Task<ResponseDto<SkillDto>> GetAsync(string version, string id)
            => _client.GetAsync<SkillDto>($"{Endpoint}/versions/{version}/skills/{id}");

        //public Task<SkillsDto?> GetSkillAsync(string version, RequestIdsDto ids, string queryparams)
        //    => _client.PostAsync<SkillsDto>($"{Endpoint}/versions/{version}/skills?{queryparams}", ids);

        //public Task<SkillsDocumentDto?> GetSkillFromDocumentAsync(string version, RequestDocumentDto data)
        //    => _client.PostAsync<SkillsDocumentDto>($"{Endpoint}/versions/{version}/extract", data);
    }
}
