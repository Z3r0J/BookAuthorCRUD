using BookAuthorCRUD.Domain.Entities;

namespace BookAuthorCRUD.Domain.Interfaces;

public interface IGenreRepository
{
    void Add(Genre genre);
    void Update(Genre genre);
    void Delete(Genre genre);
    Task<List<Genre>> GetAllGenres(CancellationToken cancellationToken = default);
    Task<Genre?> GetById(Guid id, CancellationToken cancellationToken = default);
}
