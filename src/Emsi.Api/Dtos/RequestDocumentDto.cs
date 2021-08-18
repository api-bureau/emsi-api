
namespace Emsi.Api.Dtos
{
    public class RequestDocumentDto
    {
        /// <summary>
        /// Document to be used in the skills extraction process
        /// </summary>
        public string Text { get; set; } = null!;

        /// <summary>
        /// Filter out skills with a confidence value lower than this threshold
        /// </summary>
        public double ConfidenceThreshold { get; set; }
    }
}
