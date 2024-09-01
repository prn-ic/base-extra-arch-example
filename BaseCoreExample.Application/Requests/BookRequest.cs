namespace BaseCoreExample.Application.Requests
{
    public class BookRequest : IBaseRequest
    {
        public required string Title { get; set; }
        public required string Author { get; set; }
        public int Pages { get; set; }
    }
}
