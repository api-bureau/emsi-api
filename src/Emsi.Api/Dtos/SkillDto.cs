namespace Emsi.Api.Dtos
{
    public class SkillDto
    {
        public string Id { get; set; } = null!;

        public string InfoUrl { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string RemovedDescription { get; set; } = null!;

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
