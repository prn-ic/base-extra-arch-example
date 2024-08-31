using BaseCoreExample.Core.Common;

namespace BaseCoreExample.Core.Repositories
{
    public interface IUnitOfWork
    {
        public IBaseRepository<T> Repository<T>()
            where T : IBaseEntity;

        public void Commit();
        public Task CommitAsync(CancellationToken cancellationToken = default);
    }
}
