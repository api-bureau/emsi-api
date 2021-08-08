namespace Emsi.Playground.Dtos
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
}
