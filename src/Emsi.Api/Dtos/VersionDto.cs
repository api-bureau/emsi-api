using System.Collections.Generic;

namespace Emsi.Api.Dtos
{
    public class VersionsDto
    {
        public IList<string> Data { get; set; } = null!;
    }
    //public class VersionMetadata
    //{

    //    public IList<string> Fields { get; set; } = null!;
    //    public int RemovedSkillCount { get; set; }
    //    public int SkillCount { get; set; }
    //    public IList<Types> Types { get; set; } = null!;
    //    public string Version { get; set; } = null!;

    //}

    //public class Types
    //{
    //    public string Description { get; set; } = null!;
    //    public string Id { get; set; } = null!;
    //    public string Name { get; set; } = null!;
    //}
}
