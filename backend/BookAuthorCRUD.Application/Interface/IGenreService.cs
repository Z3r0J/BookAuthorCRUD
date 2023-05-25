using BookAuthorCRUD.Contract.DTOs.Genre;
using LanguageExt.Common;

namespace BookAuthorCRUD.Application.Interface;

public interface IGenreService
{
    Task<Result<GenreResponse>> Add(GenreRequest genreRequest);
    Task<Result<bool>> Update(Guid Id, GenreRequest genreRequest);

    Task Delete(Guid id);

    Task<GenreResponse> GetByIdAsync(Guid id);

    Task<List<GenreResponse>> GetAllAsync();
}
