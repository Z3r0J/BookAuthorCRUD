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
        CreateMap<Author, AuthorResponse>().ForMember(x=>x.Books,opt=>opt.Ignore());

        CreateMap<CreateAuthorCommand, AuthorRequest>().ReverseMap();
        CreateMap<UpdateAuthorCommand, AuthorRequest>().ReverseMap();

        CreateMap<BookAuthor, BookAuthorResponse>().ReverseMap();
    }
}
