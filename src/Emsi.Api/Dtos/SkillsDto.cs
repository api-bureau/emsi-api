using System.Collections.Generic;

namespace Emsi.Api.Dtos
{
    public class SkillsDto
    {
        public IList<AttributionDto> Attributions { get; set; } = null!;

        public IList<SkillDto> Data { get; set; } = null!;
    }
}