using System.Collections.Generic;

namespace Emsi.Playground.Dtos
{
    public class VersionChangesDto
    {
        public VersionChanges Data { get; set; } = null!;
    }

    public class VersionChanges
    {
        public IList<Additions> Additions { get; set; } = null!;
        public IList<Consolidations> Consolidations { get; set; } = null!;
        public IList<Removals> Removals { get; set; } = null!;
        public IList<Renames> Renames { get; set; } = null!;
        public IList<TaggingImprovements> TaggingImprovements { get; set; } = null!;
        public IList<TypeChanges> TypeChanges { get; set; }

    }

    public class Additions
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
    }

    public class Consolidations
    {
        public string IdFrom { get; set; } = null!;
        public string IdTo { get; set; } = null!;
        public string NameFrom { get; set; } = null!;
        public string NameTo { get; set; } = null!;
    }

    public class Removals
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
    }

    public class Renames
    {
        public string Id { get; set; } = null!;
        public string NewName { get; set; } = null!;
        public string OldName { get; set; } = null!;
    }

    public class TaggingImprovements
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
    }

    public class TypeChanges
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string NewType { get; set; } = null!;
        public string OldType { get; set; } = null!;
    }


}
