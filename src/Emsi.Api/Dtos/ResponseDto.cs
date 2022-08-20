namespace Emsi.Api.Dtos
{
    public class ResponseDto<T>
    {
        public List<ErrorDto> Errors { get; set; } = new List<ErrorDto>();

        public List<AttributionDto>? Attributions { get; set; }

        public T? Data { get; set; }

        public bool IsSuccess => Data is not null && (Errors == null || Errors.Count == 0);

        public void AddError(string detail)
        {
            Errors.Add(new ErrorDto(detail));
        }
    }
}
