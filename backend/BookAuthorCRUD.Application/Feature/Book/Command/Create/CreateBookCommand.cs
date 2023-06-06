using BookAuthorCRUD.Contract.DTOs.Book;
using LanguageExt.Common;
using MediatR;

namespace BookAuthorCRUD.Application.Feature.Book.Command.Create;

public record CreateBookCommand(
    string Title,
    string Sypnosis,
    DateTime ReleaseDate,
    string Publisher,
    Guid GenreId,
    List<Guid> AuthorsId
):IRequest<Result<BookResponse>>;
