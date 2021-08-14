using System.Collections.Generic;

namespace Emsi.Api.Dtos
{
    public class SkillsDocumentDto
    {
        public IList<AttributionDto> Attributions { get; set; } = null!;

        public IList<DataDto> Data { get; set; } = null!;

        public class AttributionDto
        {
            public string Name { get; set; } = null!;

            public string Text { get; set; } = null!;
        }

        public class DataDto
        {
            public double Confidence { get; set; }

            public SkillDto Skill { get; set; } = null!;
        }

        public class SkillDto
        {
            public string Id { get; set; } = null!;

            public string InfoUrl { get; set; } = null!;

            public string Name { get; set; } = null!;

            public IList<TagDto> Tags { get; set; } = null!;

            public TypeDto Type { get; set; } = null!;
        }

        public class TagDto
        {
            public string Key { get; set; } = null!;

            public string Value { get; set; } = null!;
        }

        public class TypeDto
        {
            public string Id { get; set; } = null!;

            public string Name { get; set; } = null!;
        }
    }
}
