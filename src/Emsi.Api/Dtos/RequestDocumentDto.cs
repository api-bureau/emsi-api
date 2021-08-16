
namespace Emsi.Api.Dtos
{
    public class RequestDocumentDto
    {
        public string Text { get; set; } = null!;

        public double ConfidenceThreshold { get; set; }
    }
}
