using BaseCoreExample.Core.Common;

namespace BaseCoreExample.Core.Entities
{
    public class Book : BaseEntity<Guid>
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int Pages { get; set;}
    }
}
