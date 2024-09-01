using AutoMapper;
using BaseCoreExample.Application.Requests;
using BaseCoreExample.Application.Responses;
using BaseCoreExample.Core.Entities;

namespace BaseCoreExample.Application.Mappings
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<BookRequest, BookResponse>().ReverseMap();
            CreateMap<Book, BookResponse>().ReverseMap();
            CreateMap<BookRequest, Book>().ReverseMap();
        }
    }
}
