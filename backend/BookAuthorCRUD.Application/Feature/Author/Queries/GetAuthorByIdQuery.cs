using BookAuthorCRUD.Contract.DTOs.Author;
using MediatR;

namespace BookAuthorCRUD.Application.Feature.Author.Queries;

public record GetAuthorByIdQuery(Guid Id) : IRequest<AuthorResponse>;
