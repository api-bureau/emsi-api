using System.Collections.Generic;

namespace Emsi.Api.Dtos
{
    public class SkillsDocumentDto
    {
        public IList<AttributionDto> Attributions { get; set; } = null!;

        public IList<DataDto> Data { get; set; } = null!;

        public class DataDto
        {
            public double Confidence { get; set; }

            public SkillDto Skill { get; set; } = null!;
        }
    }
}
