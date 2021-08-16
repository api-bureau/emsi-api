namespace Emsi.Api.Dtos
{
    public class StatusDto
    {
        public string Message { get; set; } = null!;
        public bool Healthy { get; set; }
    }
}
