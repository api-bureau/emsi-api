namespace Emsi.Api.Dtos;

public class SkillDocumentDto
{
    public double Confidence { get; set; }

    public SkillDto Skill { get; set; } = null!;
}
