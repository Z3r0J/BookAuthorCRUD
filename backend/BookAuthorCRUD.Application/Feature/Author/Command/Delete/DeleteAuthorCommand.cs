using MediatR;
namespace BookAuthorCRUD.Application.Feature.Author.Command.Delete;

public record DeleteAuthorCommand(Guid Id) : IRequest<Unit>;
