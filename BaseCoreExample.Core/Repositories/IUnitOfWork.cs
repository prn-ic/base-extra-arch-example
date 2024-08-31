using BaseCoreExample.Core.Common;

namespace BaseCoreExample.Core.Repositories
{
    public interface IUnitOfWork
    {
        public IBaseRepository<T> Repository<T>()
            where T : class, IBaseEntity;

        public IBookRepository Books { get; }
        public void Commit();
        public Task CommitAsync(CancellationToken cancellationToken = default);
    }
}
