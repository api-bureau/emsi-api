using System.Collections.Generic;

namespace Emsi.Api.Dtos
{
    public class SkillsDto
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
            public string Id { get; set; } = null!;

            public string InfoUrl { get; set; } = null!;

            public string Name { get; set; } = null!;

            public TypeDto Type { get; set; } = null!;

        }

        public class TypeDto
        {
            public string Id { get; set; } = null!;

            public string Name { get; set; } = null!;

        }
    }
}