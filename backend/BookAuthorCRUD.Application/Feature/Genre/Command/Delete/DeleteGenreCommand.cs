using MediatR;

namespace BookAuthorCRUD.Application.Feature.Genre.Command.Delete;

public record DeleteGenreCommand(Guid Id) : IRequest<Unit>;
