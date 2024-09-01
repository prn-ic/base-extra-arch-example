using BaseCoreExample.Application.Commands;
using BaseCoreExample.Application.Queries;
using BaseCoreExample.Application.Responses;
using BaseCoreExample.Core.Common;
using BaseCoreExample.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BaseCoreExample.WebApi.Controllers
{
    public abstract class BaseController<TEntity, TRequest, TResponse>(IMediator mediator)
        : ControllerBase
        where TEntity : class, IBaseEntity
        where TRequest : class, Application.Requests.IBaseRequest
        where TResponse : class, IBaseResponse
    {
        protected readonly IMediator _mediator = mediator;

        [HttpGet("all")]
        public virtual async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(
                new BaseFindQuery<TEntity, TResponse>(new EmptySpecification<TEntity>()),
                cancellationToken
            );

            return Ok(response);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Craete(
            TRequest request,
            CancellationToken cancellationToken
        )
        {
            var response = await _mediator.Send(
                new BaseSaveChangesCommand<TRequest, TResponse>(request),
                cancellationToken
            );

            return Ok(response);
        }
    }
}
