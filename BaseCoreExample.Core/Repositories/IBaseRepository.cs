using BaseCoreExample.Core.Common;
using BaseCoreExample.Core.Specifications;

namespace BaseCoreExample.Core.Repositories
{
    public interface IBaseRepository<T>
        where T : IBaseEntity
    {
        public Task<IEnumerable<T>> Find(
            Specification<T> specification,
            CancellationToken cancellationToken = default
        );
        public Task<T?> FindById<TId>(TId id, CancellationToken cancellationToken = default);
        public Task<T> SaveChanges(T entity, CancellationToken cancellationToken = default);
        public Task Delete<TId>(TId id, CancellationToken cancellationToken = default);
    }
}
