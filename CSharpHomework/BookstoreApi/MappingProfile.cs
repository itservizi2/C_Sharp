using AutoMapper;
using BookstoreApi.Models;
using BookstoreApi.Dtos;

namespace BookstoreApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<CreateBookDto, Book>();
        }
    }
}
