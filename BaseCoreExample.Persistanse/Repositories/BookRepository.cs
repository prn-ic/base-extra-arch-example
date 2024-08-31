using BaseCoreExample.Core.Entities;
using BaseCoreExample.Persistanse.Data;

namespace BaseCoreExample.Persistanse.Repositories
{
    public class BookRepository : BaseRepository<Book>
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }
    }
}