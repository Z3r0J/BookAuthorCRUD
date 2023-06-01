using BookAuthorCRUD.Domain.Entities;

namespace BookAuthorCRUD.Domain.Interfaces
{
    public interface IBookAuthorRepository
    {
        Task DeleteAuthors(Guid BookId,CancellationToken cancellationToken = default);
        Task AddBookAuthor(BookAuthor bookAuthor, CancellationToken cancellationToken = default);
    }
}
