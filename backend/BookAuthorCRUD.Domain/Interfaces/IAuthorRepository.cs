using BookAuthorCRUD.Domain.Entities;

namespace BookAuthorCRUD.Domain.Interfaces;

public interface IAuthorRepository
{
    void Add(Author author);
    void Update(Author author);
    void Delete(Author author);
    Task<List<Author>> GetAllAuthor(CancellationToken cancellationToken = default);
    Task<Author?> GetById(Guid id, CancellationToken cancellationToken = default);
}
