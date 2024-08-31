using AutoMapper;
using BaseCoreExample.Application.Responses;
using BaseCoreExample.Core.Entities;
using BaseCoreExample.Core.Repositories;

namespace BaseCoreExample.Application.Queries
{
    /// <summary>
    /// P.S: Можно и так %)
    /// </summary>
    public class GetAllBooksQuery : BaseFindQuery<Book, BookResponse>
    {
        public GetAllBooksQuery()
            : base(new EmptySpecification<Book>()) { }
    }

    public class GetAllBooksQueryHandler : BaseFindQueryHandler<Book, BookResponse>
    {
        public GetAllBooksQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork) { }
    }
}
