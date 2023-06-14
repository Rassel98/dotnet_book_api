using AutoMapper;
using my_books.Dto;
using my_books.Models;

namespace my_books.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
            CreateMap<Author, AuthorDto>();
            CreateMap<Author, AuthorDto2>();
            CreateMap<AuthorDto, Author>();
            CreateMap<Publisher, PublisherDto>();
            CreateMap<PublisherDto, Publisher>();
        }

        
    }
}
