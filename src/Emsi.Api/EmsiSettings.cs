namespace Emsi.Api
{
    public class EmsiSettings
    {
        public string BaseUrl { get; set; } = null!;
        public string ClientId { get; set; } = null!;
        public string ClientSecret { get; set; } = null!;
        public string Scope { get; set; } = null!;
        public string AuthorisationUrl { get; set; } = null!;
    }
}
