
namespace Emsi.Api.Dtos
{
    public class RequestDocumentDto
    {
        public string text { get; set; } = null!;

        public double confidenceThreshold { get; set; }
    }
}
