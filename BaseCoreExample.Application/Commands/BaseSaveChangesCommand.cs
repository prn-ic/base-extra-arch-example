using AutoMapper;
using BaseCoreExample.Core.Common;
using BaseCoreExample.Core.Repositories;
using MediatR;

namespace BaseCoreExample.Application.Commands
{
    public class BaseSaveChangesCommand<TRequest, TResponse>(TRequest request) : IRequest<TResponse>
        where TRequest : class
        where TResponse : class
    {
        public TRequest Request { get; } = request;
    }

    public abstract class BaseSaveChangesCommandHandler<TEntity, TCommand, TRequest, TResponse>(
        IUnitOfWork unitOfWork,
        IMapper mapper
    ) : IRequestHandler<TCommand, TResponse>
        where TCommand : BaseSaveChangesCommand<TRequest, TResponse>
        where TEntity : class, IBaseEntity
        where TRequest : class
        where TResponse : class
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        private readonly IMapper _mapper = mapper;

        public virtual async Task<TResponse> Handle(
            TCommand request,
            CancellationToken cancellationToken
        )
        {
            var repository = _unitOfWork.Repository<TEntity>();
            var result = await repository.SaveChanges(
                entity: _mapper.Map<TEntity>(request.Request),
                cancellationToken: cancellationToken
            );
            await _unitOfWork.CommitAsync(cancellationToken);

            return _mapper.Map<TResponse>(result);
        }
    }
}
