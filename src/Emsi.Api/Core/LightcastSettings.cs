namespace Emsi.Api.Core;

public class LightcastSettings
{
    public string BaseUrl { get; set; } = null!;
    public string ClientId { get; set; } = null!;
    public string ClientSecret { get; set; } = null!;
    public string Scope { get; set; } = null!;
    public string AuthorisationUrl { get; set; } = null!;
}
