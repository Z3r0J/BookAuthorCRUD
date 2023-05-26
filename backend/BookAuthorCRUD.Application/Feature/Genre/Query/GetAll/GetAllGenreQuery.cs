using BookAuthorCRUD.Contract.DTOs.Genre;
using MediatR;

namespace BookAuthorCRUD.Application.Feature.Genre.Query.GetAll;

public record GetAllGenreQuery() : IRequest<IList<GenreResponse>>;
