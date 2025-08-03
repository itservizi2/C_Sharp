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
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author != null ? src.Author.Name : null))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : null));

            CreateMap<CreateBookDto, Book>();


            CreateMap<Author, AuthorDto>();
            CreateMap<CreateAuthorDto, Author>();


            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
        }
    }
}