namespace BaseCoreExample.Application.Responses
{
    public class BookResponse : IBaseResponse
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
    }
}