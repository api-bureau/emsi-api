using System.Collections.Generic;

namespace Emsi.Api.Dtos
{
    public class SkillsDocumentDto
    {
        public IList<AttributionDto> attributions { get; set; } = null!;

        public IList<DataDto> data { get; set; } = null!;

        public class AttributionDto
        {
            public string name { get; set; } = null!;

            public string text { get; set; } = null!;
        }

        public class DataDto
        {
            public double confidence { get; set; }

            public SkillDto skill { get; set; } = null!;
        }

        public class SkillDto
        {
            public string id { get; set; } = null!;

            public string infoUrl { get; set; } = null!;

            public string name { get; set; } = null!;

            public IList<TagDto> tags { get; set; } = null!;

            public TypeDto type { get; set; } = null!;
        }

        public class TagDto
        {
            public string key { get; set; } = null!;

            public string value { get; set; } = null!;
        }

        public class TypeDto
        {
            public string id { get; set; } = null!;

            public string name { get; set; } = null!;
        }
    }
}
