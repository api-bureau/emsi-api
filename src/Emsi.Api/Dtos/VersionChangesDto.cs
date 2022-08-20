namespace Emsi.Api.Dtos;

public class VersionChangesDto
{
    public IList<Additions> Additions { get; set; } = null!;
    public IList<Consolidations> Consolidations { get; set; } = null!;
    public IList<IdNameDto> Removals { get; set; } = null!;
    public IList<Renames> Renames { get; set; } = null!;
    public IList<IdNameDto> TaggingImprovements { get; set; } = null!;
    public IList<TypeChanges> TypeChanges { get; set; } = null!;
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

public class IdNameDto
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

public class TypeChanges : IdNameDto
{
    public string NewType { get; set; } = null!;
    public string OldType { get; set; } = null!;
}

