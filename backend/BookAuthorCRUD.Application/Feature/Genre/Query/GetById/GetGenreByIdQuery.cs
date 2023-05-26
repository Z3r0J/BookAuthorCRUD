using BookAuthorCRUD.Contract.DTOs.Genre;
using MediatR;

namespace BookAuthorCRUD.Application.Feature.Genre.Query.GetById;

public record GetGenreByIdQuery(Guid Id) : IRequest<GenreResponse>;
