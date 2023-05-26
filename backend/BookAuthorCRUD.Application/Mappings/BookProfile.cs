using AutoMapper;
using BookAuthorCRUD.Application.Feature.Book.Command.Create;
using BookAuthorCRUD.Application.Feature.Book.Command.Update;
using BookAuthorCRUD.Contract.DTOs.Book;
using BookAuthorCRUD.Domain.Entities;

namespace BookAuthorCRUD.Application.Mappings;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookResponse>()
            .ForMember(x=>x.Genre,opt=>opt.Ignore());

        CreateMap<CreateBookCommand, BookRequest>().ReverseMap();
        CreateMap<UpdateBookCommand, BookRequest>().ReverseMap();
    }
}
