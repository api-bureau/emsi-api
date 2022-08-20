namespace Emsi.Api.Endpoints;

public class SkillEndpoint
{
    private const string Endpoint = "/skills";
    private readonly ApiConnection _apiConnection;

    public SkillEndpoint(ApiConnection apiConnection) => _apiConnection = apiConnection;

    public Task<ResponseDto<StatusDto>> GetStatusAsync()
        => _apiConnection.GetAsync<StatusDto>($"{Endpoint}/status");

    public Task<ResponseDto<MetaDto>> GetMetaAsync()
        => _apiConnection.GetAsync<MetaDto>($"{Endpoint}/meta");

    public Task<ResponseDto<List<string>>> GetVersionsAsync()
        => _apiConnection.GetAsync<List<string>>($"{Endpoint}/versions");

    public Task<ResponseDto<SkillDto>> GetAsync(string version, string id)
        => _apiConnection.GetAsync<SkillDto>($"{SkillUrlByVersion(version)}/{id}");

    public Task<ResponseDto<List<SkillDto>>> GetAsync(string version, int limit)
        => _apiConnection.GetAsync<List<SkillDto>>($"{SkillUrlByVersion(version)}?limit={limit}");

    public Task<ResponseDto<List<SkillDto>>> GetAsync(string version, SkillQuery query)
        => _apiConnection.GetAsync<List<SkillDto>>($"{SkillUrlByVersion(version)}?{query.Create()}");

    public Task<ResponseDto<List<SkillDto>>> GetAsync(string version, IList<string> ids, SkillQueryBase query)
        => _apiConnection.PostAsync<List<SkillDto>>($"{SkillUrlByVersion(version)}?{query.Create()}", new { Ids = ids });

    [Obsolete("Use SkillQuery instead")]
    public Task<ResponseDto<List<SkillDto>>> GetSkillsAsync(string version, string queryparams)
        => _apiConnection.GetAsync<List<SkillDto>>($"{SkillUrlByVersion(version)}?{queryparams}");

    //ToDo refactor RequestIds to anonymous and use  List<string>
    [Obsolete("Use SkillQueryBase instead")]
    public Task<ResponseDto<List<SkillDto>>> GetAsync(string version, IList<string> ids, string queryparams)
        => _apiConnection.PostAsync<List<SkillDto>>($"{SkillUrlByVersion(version)}?{queryparams}", new { Ids = ids });

    public Task<ResponseDto<VersionMetadataDto>> GetVersionsMetaDataAsync(string version)
        => _apiConnection.GetAsync<VersionMetadataDto>($"{BaseUrlByVersion(version)}");

    public Task<ResponseDto<VersionChangesDto>> GetVersionChangesAsync(string version)
        => _apiConnection.GetAsync<VersionChangesDto>($"{BaseUrlByVersion(version)}/changes");

    //ToDo refactor RequestIds to anonymous and use List<string>
    public Task<ResponseDto<List<SkillDto>>> GetRelatedSkillsAsync(string version, IList<string> ids)
        => _apiConnection.PostAsync<List<SkillDto>>($"{BaseUrlByVersion(version)}/related", new { Ids = ids });

    public Task<ResponseDto<List<SkillDocumentDto>>> ExtarctSkillsAsync(string version, RequestDocumentDto data)
        => _apiConnection.PostAsync<List<SkillDocumentDto>>($"{BaseUrlByVersion(version)}/extract", data);

    //ToDo refactor RequestSourceTraceDto to anonymous
    public Task<ResponseDto<SourceTracingDto>> ExtractSkillsWithSourceTracingAsync(string version, RequestSourceTraceDto text)
        => _apiConnection.PostAsync<SourceTracingDto>($"{BaseUrlByVersion(version)}/extract/trace", text);

    private string BaseUrlByVersion(string version) => $"{Endpoint}/versions/{version}";

    private string SkillUrlByVersion(string version) => $"{BaseUrlByVersion(version)}/skills";
}
