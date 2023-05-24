using AutoMapper;
using BookAuthorCRUD.Contract.DTOs.Book;
using BookAuthorCRUD.Domain.Entities;

namespace BookAuthorCRUD.Application.Mappings;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookResponse>()
            .ForMember(
                x => x.Authors,
                config => config.MapFrom(x => x.Authors.Select(x => x.Author))
            );
    }
}
