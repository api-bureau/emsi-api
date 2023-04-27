using Microsoft.Extensions.Options;

namespace Emsi.Api;

public class EmsiClient
{
    private readonly ApiConnection _apiConnection;

    public SkillEndpoint Skills { get; set; }

    public EmsiClient(HttpClient client, IOptions<LightcastSettings> settings)
    {
        _apiConnection = new ApiConnection(client, settings);

        Skills = new SkillEndpoint(_apiConnection);
    }
}