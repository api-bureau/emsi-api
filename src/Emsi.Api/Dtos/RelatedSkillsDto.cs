using System.Collections.Generic;

namespace Emsi.Api
{
    public class RelatedSkillsDto
    {
        public List<Attributions> Attributions { get; set; } = null!;
        public List<Data> Data { get; set; } = null!;
    }

    public class Attributions
    {
        public string Name { get; set; } = null!;
        public string Text { get; set; } = null!;
    }
    public class Data
    {
        public string Id { get; set; } = null!;
        public string InfoUrl { get; set; } = null!;
        public string Name { get; set; } = null!;
        public Type Type { get; set; } = null!;
    }

    public class Type
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}