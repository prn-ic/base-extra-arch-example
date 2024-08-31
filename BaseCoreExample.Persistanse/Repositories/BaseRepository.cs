using BaseCoreExample.Core.Common;
using BaseCoreExample.Core.Repositories;
using BaseCoreExample.Core.Specifications;
using BaseCoreExample.Persistanse.Data;
using Microsoft.EntityFrameworkCore;

namespace BaseCoreExample.Persistanse.Repositories
{
    public class BaseRepository<T>(AppDbContext context) : IBaseRepository<T>
        where T : class, IBaseEntity
    {
        private readonly AppDbContext _context = context;

        public virtual async Task<IEnumerable<T>> Find(
            Specification<T> specification,
            CancellationToken cancellationToken = default
        ) =>
            await _context
                .Set<T>()
                .Where(specification.ToExpression())
                .ToListAsync(cancellationToken);

        public async Task<T?> FindById<TId>(
            TId id,
            CancellationToken cancellationToken = default
        ) =>
            await _context
                .Set<T>()
                .FindAsync(keyValues: [id], cancellationToken: cancellationToken);

        public virtual async Task<T> SaveChanges(
            T entity,
            CancellationToken cancellationToken = default
        )
        {
            bool isExist = await _context
                .Set<T>()
                .AnyAsync(x => x.Equals(entity), cancellationToken);
            var result = isExist
                ? _context.Set<T>().Update(entity)
                : await _context
                    .Set<T>()
                    .AddAsync(entity: entity, cancellationToken: cancellationToken);

            return result.Entity;
        }

        public virtual async Task Delete<TId>(TId id, CancellationToken cancellationToken = default)
        {
            var entity = await _context
                .Set<T>()
                .FindAsync(keyValues: [id], cancellationToken: cancellationToken);

            if (entity is null)
                throw new Exception("Тут будет доменной эксепшин");

            _context.Set<T>().Remove(entity);
        }
    }
}
