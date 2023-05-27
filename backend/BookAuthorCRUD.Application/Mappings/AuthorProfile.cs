using BookAuthorCRUD.Contract.DTOs.Author;
using BookAuthorCRUD.Domain.Entities;
using AutoMapper;
using BookAuthorCRUD.Application.Feature.Author.Command.Create;
using BookAuthorCRUD.Application.Feature.Author.Command.Update;

namespace BookAuthorCRUD.Application.Mappings;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<AuthorResponse, Author>().ForMember(x => x.Books, opt => opt.Ignore());
        CreateMap<Author, AuthorResponse>()
            .ForMember(x => x.BookCount, opt => opt.MapFrom(p => p.Books.Count));

        CreateMap<CreateAuthorCommand, AuthorRequest>().ReverseMap();
        CreateMap<UpdateAuthorCommand, AuthorRequest>().ReverseMap();

        CreateMap<BookAuthorResponse, BookAuthor>()
            .ForMember(x => x.Book, opt => opt.Ignore())
            .ForMember(x => x.Author, opt => opt.Ignore())
            .ReverseMap();
    }
}
