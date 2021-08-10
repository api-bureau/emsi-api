namespace Emsi.Api.Dtos
{
    //ToDo Refactor to generic container

    public class MetaDto
    {
        public MetaDataDto Data { get; set; } = null!;
    }

    public class MetaDataDto
    {
        public string LatestVersion { get; set; } = null!;
        public AttributionDto Attribution { get; set; } = null!;
    }

    public class AttributionDto
    {
        public string Body { get; set; } = null!;

        public string Title { get; set; } = null!;
    }
}
