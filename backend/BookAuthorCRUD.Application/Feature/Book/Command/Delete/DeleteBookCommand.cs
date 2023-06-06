using MediatR;

namespace BookAuthorCRUD.Application.Feature.Book.Command.Delete;

public record DeleteBookCommand(Guid Id) : IRequest<Unit>;
