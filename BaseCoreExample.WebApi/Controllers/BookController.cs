using BaseCoreExample.Application.Requests;
using BaseCoreExample.Application.Responses;
using BaseCoreExample.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BaseCoreExample.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : BaseController<Book, BookRequest, BookResponse>
    {
        public BookController(IMediator mediator) : base(mediator)
        {
        }
    }
}