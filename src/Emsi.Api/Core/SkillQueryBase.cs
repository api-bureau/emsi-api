namespace Emsi.Api.Core;

public class SkillQueryBase
{
    /// <summary>
    /// Default "id,name,type,infoUrl"
    /// </summary>
    public string Fields { get; set; } = "id,name,type,infoUrl";

    public List<string> TypeIds { get; set; } = new List<string>();


    public virtual string Create()
    {
        var parameters = new List<string>();

        if (TypeIds.Count > 0)
        {
            parameters.Add($"typeIds={Uri.EscapeDataString(string.Join(',', TypeIds))}");
        }

        if (!string.IsNullOrWhiteSpace(Fields))
        {
            parameters.Add($"fields={Uri.EscapeDataString(Fields)}");
        }

        return string.Join('&', parameters);
    }
}