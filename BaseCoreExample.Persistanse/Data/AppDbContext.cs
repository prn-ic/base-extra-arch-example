using BaseCoreExample.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseCoreExample.Persistanse.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Book> Books => Set<Book>();
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

    }
}
