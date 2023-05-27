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
        CreateMap<BookResponse, Book>()
            .ForMember(x => x.Genre, opt => opt.Ignore())
            .ForMember(x => x.Authors, opt => opt.Ignore())
            .ReverseMap()
            .ForMember(
                x => x.AuthorList,
                opt =>
                    opt.MapFrom(
                        x =>
                            x.Authors
                                .Select(x => $"{x.Author.FirstName} {x.Author.LastName}")
                                .ToList() ?? new()
                    )
            );
        ;

        CreateMap<CreateBookCommand, BookRequest>().ReverseMap();
        CreateMap<UpdateBookCommand, BookRequest>().ReverseMap();
    }
}
