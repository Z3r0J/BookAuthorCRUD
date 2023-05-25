using BookAuthorCRUD.Contract.DTOs.Author;
using BookAuthorCRUD.Domain.Entities;
using AutoMapper;

namespace BookAuthorCRUD.Application.Mappings;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<Author, AuthorResponse>()
            .ForMember(x => x.Books, opt => opt.MapFrom(x => x.Books.Select(x => x.Book)));
    }
}
