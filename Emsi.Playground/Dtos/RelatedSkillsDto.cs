using System.Collections.Generic;

namespace Emsi.Playground.Dtos
{
    class RelatedSkillsDto
    {
        public IList<Attributions> Attributions { get; set; } = null!;
        public IList<RelatedSkills> RelatedSkills { get; set; } = null!;
    }

    public class Attributions
    {
        public string Name { get; set; } = null!;
        public string Text { get; set; } = null!;
    }
    public class RelatedSkills
    {
        public string Id { get; set; } = null!;
        public string InfoUrl { get; set; } = null!;
        public string Name { get; set; } = null!;
        public Type Type { get; set; } = null!;
    }

    public class Type
    {
        public string id { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
