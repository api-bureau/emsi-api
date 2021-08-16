using System.Collections.Generic;

namespace Emsi.Api.Dtos
{
    public class VersionMetadataDto
    {

        public IList<string> Fields { get; set; } = null!;
        public int RemovedSkillCount { get; set; }
        public int SkillCount { get; set; }
        public IList<TypesDto> Types { get; set; } = null!;
        public string Version { get; set; } = null!;
    }

    public class TypesDto
    {
        public string Description { get; set; } = null!;
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}