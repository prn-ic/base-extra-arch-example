using AutoMapper;
using BaseCoreExample.Application.Responses;
using BaseCoreExample.Core.Common;
using BaseCoreExample.Core.Repositories;
using BaseCoreExample.Core.Specifications;
using MediatR;

namespace BaseCoreExample.Application.Queries
{
    public class BaseFindQuery<TEntity, TResponse>(Specification<TEntity> specification)
        : IRequest<IEnumerable<TResponse>>
        where TEntity : IBaseEntity
        where TResponse : IBaseResponse
    {
        public Specification<TEntity> Specification { get; } = specification;
    }

    public class BaseFindQueryHandler<TEntity, TResponse>(IMapper mapper, IUnitOfWork unitOfWork)
        : IRequestHandler<BaseFindQuery<TEntity, TResponse>, IEnumerable<TResponse>>
        where TEntity : class, IBaseEntity
        where TResponse : IBaseResponse
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public virtual async Task<IEnumerable<TResponse>> Handle(
            BaseFindQuery<TEntity, TResponse> request,
            CancellationToken cancellationToken
        )
        {
            var repository = _unitOfWork.Repository<TEntity>();
            var result = await repository.Find(
                specification: request.Specification,
                cancellationToken: cancellationToken
            );

            return _mapper.Map<IEnumerable<TResponse>>(result);
        }
    }
}
