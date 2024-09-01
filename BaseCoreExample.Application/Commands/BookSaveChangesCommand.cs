using AutoMapper;
using BaseCoreExample.Application.Requests;
using BaseCoreExample.Application.Responses;
using BaseCoreExample.Core.Entities;
using BaseCoreExample.Core.Repositories;

namespace BaseCoreExample.Application.Commands
{
    public class BookSaveChangesCommandgHandler
        : BaseSaveChangesCommandHandler<
            Book,
            BaseSaveChangesCommand<BookRequest, BookResponse>,
            BookRequest,
            BookResponse
        >
    {
        public BookSaveChangesCommandgHandler(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper) { }
    }
}
