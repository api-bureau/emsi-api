namespace Emsi.Api.Core;

public class SkillQuery : SkillQueryBase
{
    public string? Query { get; set; }

    public int Limit { get; set; }

    public override string Create()
    {
        var parameters = new List<string>();
        var baseQuery = base.Create();

        if (!string.IsNullOrEmpty(baseQuery))
        {
            parameters.Add(baseQuery);
        }

        if (!string.IsNullOrWhiteSpace(Query))
        {
            parameters.Add($"q={Uri.EscapeDataString(Query)}");
        }

        if (Limit > 0)
        {
            parameters.Add($"limit={Limit}");
        }

        return string.Join('&', parameters);
    }
}