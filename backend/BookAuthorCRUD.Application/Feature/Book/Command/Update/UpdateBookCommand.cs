using LanguageExt.Common;
using MediatR;

namespace BookAuthorCRUD.Application.Feature.Book.Command.Update;

public record UpdateBookCommand(
    Guid Id,
    string Title,
    string Sypnosis,
    DateTime ReleaseDate,
    string Publisher,
    Guid GenreId,
    List<Guid>? AuthorsId
):IRequest<Result<bool>>;
