namespace Emsi.Api.Dtos
{
    //ToDo Refactor to generic container

    public class StatusDto
    {
        public StatusDataDto Data { get; set; } = null!;
    }

    public class StatusDataDto
    {
        public string Message { get; set; } = null!;
        public bool Healthy { get; set; }
    }

    public class ResponseDto<T>
    {
        public ErrorDto? Error { get; set; }
            
        public T Value { get; set; }

        public bool IsSuccess => Error == null;
    }

    public class ErrorDto
    {

    }
}
