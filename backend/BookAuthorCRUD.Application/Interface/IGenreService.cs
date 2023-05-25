using BookAuthorCRUD.Contract.DTOs.Author;
using BookAuthorCRUD.Contract.DTOs.Genre;
using BookAuthorCRUD.Domain.Entities;

namespace BookAuthorCRUD.Application.Interface;

public interface IGenreService
{
    Task <GenreResponse> Add(GenreRequest genreRequest);
    Task Update(Guid Id, GenreRequest genreRequest);

    Task Delete(Guid id);

    Task<GenreResponse> GetByIdAsync(Guid id);

    Task<List<GenreResponse>> GetAllAsync();
}
