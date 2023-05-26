using BookAuthorCRUD.Contract.DTOs.Author;
using MediatR;

namespace BookAuthorCRUD.Application.Feature.Author.Queries.GetAll;

public record GetAllAuthorQuery() : IRequest<IList<AuthorResponse>>;
