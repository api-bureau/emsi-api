namespace Emsi.Api.Dtos;

public class ErrorDto
{
    public string? Detail { get; set; }
    public string? Title { get; set; }
    public string? Status { get; set; }

    public ErrorDto() { }
    public ErrorDto(string detail)
    {
        Detail = detail;
    }
}
