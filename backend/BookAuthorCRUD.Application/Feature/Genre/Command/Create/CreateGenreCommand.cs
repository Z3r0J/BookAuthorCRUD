using BookAuthorCRUD.Contract.DTOs.Genre;
using LanguageExt.Common;
using MediatR;

namespace BookAuthorCRUD.Application.Feature.Genre.Command.Create;

public record CreateGenreCommand(string Name) : IRequest<Result<GenreResponse>>;
