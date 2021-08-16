namespace Emsi.Api.Dtos
{
    public class MetaDto
    {
        public string LatestVersion { get; set; } = null!;
        public BodyTitleDto Attribution { get; set; } = null!;
    }

    public class BodyTitleDto
    {
        public string Body { get; set; } = null!;

        public string Title { get; set; } = null!;
    }
}
