using Emsi.Api.Core;
using Emsi.Api.Dtos;

namespace Emsi.Api.Endpoints;

public class SkillEndpoint
{
    private const string Endpoint = "/skills";
    private readonly EmsiClient _client;

    public SkillEndpoint(EmsiClient client) => _client = client;

    public Task<ResponseDto<StatusDto>> GetStatusAsync()
        => _client.GetAsync<StatusDto>($"{Endpoint}/status");

    public Task<ResponseDto<MetaDto>> GetMetaAsync()
        => _client.GetAsync<MetaDto>($"{Endpoint}/meta");

    public Task<ResponseDto<List<string>>> GetVersionsAsync()
        => _client.GetAsync<List<string>>($"{Endpoint}/versions");

    public Task<ResponseDto<SkillDto>> GetAsync(string version, string id)
        => _client.GetAsync<SkillDto>($"{Endpoint}/versions/{version}/skills/{id}");

    public Task<ResponseDto<List<SkillDto>>> GetAsync(string version, SkillQuery query)
        => _client.GetAsync<List<SkillDto>>($"{Endpoint}/versions/{version}/skills?{query.Create()}");

    public Task<ResponseDto<List<SkillDto>>> GetAsync(string version, IList<string> ids, SkillQueryBase query)
        => _client.PostAsync<List<SkillDto>>($"{Endpoint}/versions/{version}/skills?{query.Create()}", new { Ids = ids });

    [Obsolete("Use SkillQuery instead")]
    public Task<ResponseDto<List<SkillDto>>> GetSkillsAsync(string version, string queryparams)
        => _client.GetAsync<List<SkillDto>>($"{Endpoint}/versions/{version}/skills?{queryparams}");

    //ToDo refactor RequestIds to anonymous and use  List<string>
    [Obsolete("Use SkillQueryBase instead")]
    public Task<ResponseDto<List<SkillDto>>> GetAsync(string version, IList<string> ids, string queryparams)
        => _client.PostAsync<List<SkillDto>>($"{Endpoint}/versions/{version}/skills?{queryparams}", new { Ids = ids });

    public Task<ResponseDto<VersionMetadataDto>> GetVersionsMetaDataAsync(string version)
        => _client.GetAsync<VersionMetadataDto>($"{Endpoint}/versions/{version}");

    public Task<ResponseDto<VersionChangesDto>> GetVersionChangesAsync(string version)
        => _client.GetAsync<VersionChangesDto>($"{Endpoint}/versions/{version}/changes");

    //ToDo refactor RequestIds to anonymous and use List<string>
    public Task<ResponseDto<List<SkillDto>>> GetRelatedSkillsAsync(string version, IList<string> ids)
        => _client.PostAsync<List<SkillDto>>($"{Endpoint}/versions/{version}/related", new { Ids = ids });

    public Task<ResponseDto<List<SkillDocumentDto>>> ExtarctSkillsAsync(string version, RequestDocumentDto data)
        => _client.PostAsync<List<SkillDocumentDto>>($"{Endpoint}/versions/{version}/extract", data);

    //ToDo refactor RequestSourceTraceDto to anonymous
    public Task<ResponseDto<SourceTracingDto>> ExtractSkillsWithSourceTracingAsync(string version, RequestSourceTraceDto text)
        => _client.PostAsync<SourceTracingDto>($"{Endpoint}/versions/{version}/extract/trace", text);
}
