namespace Emsi.Api.Core;

public class SkillQuery : SkillQueryBase
{
    public string? Query { get; set; }

    public int Limit { get; set; }

    //ToDo Implement query buider
    public override string Create()
    {
        return string.Empty;
    }
}
