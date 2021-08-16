using Emsi.Api.Dtos;
using System.Collections.Generic;

namespace Emsi.Api
{
    public class RelatedSkillsDto
    {
        public List<AttributionDto> Attributions { get; set; } = null!;
        public List<SkillDto> Data { get; set; } = null!;
    }
}