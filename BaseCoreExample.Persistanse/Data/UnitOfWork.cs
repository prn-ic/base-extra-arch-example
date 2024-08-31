using BaseCoreExample.Core.Common;
using BaseCoreExample.Core.Repositories;
using BaseCoreExample.Persistanse.Repositories;

namespace BaseCoreExample.Persistanse.Data
{
    public class UnitOfWork(AppDbContext context, IBookRepository bookRepository) : IUnitOfWork
    {
        private readonly AppDbContext _context = context;

        public IBookRepository Books { get; } = bookRepository;

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public IBaseRepository<T> Repository<T>()
            where T : class, IBaseEntity
        {
            return new BaseRepository<T>(_context);
        }
    }
}
