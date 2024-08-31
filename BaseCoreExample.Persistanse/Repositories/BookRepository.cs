using BaseCoreExample.Core.Entities;
using BaseCoreExample.Core.Repositories;
using BaseCoreExample.Persistanse.Data;

namespace BaseCoreExample.Persistanse.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context)
            : base(context) { }
    }
}
