using BookAuthorCRUD.Domain.Entities;

namespace BookAuthorCRUD.Domain.Interfaces;

public interface IBookRepository
{
    void Add(Book book);
    void Update(Book book);
    void Delete(Book book);
    Task<List<Book>> GetAllBooks(CancellationToken cancellationToken = default);
    Task<Book?> GetById(Guid id, CancellationToken cancellationToken = default);
    Task<List<Book>> GetBooksByAuthorId(
        Guid authorId,
        CancellationToken cancellationToken = default
    );
}
