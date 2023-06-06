using BookAuthorCRUD.Domain.Common;

namespace BookAuthorCRUD.Domain.Entities
{
    public class BookAuthor : AuditableBaseEntity
    {
        public Guid AuthorId { get; private set; } = Guid.Empty;
        public Author Author { get; private set; }

        public Guid BookId { get; private set; } = Guid.Empty;
        public Book Book { get; private set; }

        public BookAuthor()
        {

        }
        private BookAuthor(Guid id,Guid authorId, Guid bookId)
        {
            Id = id;
            AuthorId = authorId;
            BookId = bookId;
        }

        public static BookAuthor Create(Guid authorId, Guid bookId)
        {
            var bookAuthor = new BookAuthor(Guid.NewGuid(),authorId, bookId);

            return bookAuthor;
        }

        public void Update(Guid authorId, Guid bookId)
        {
            AuthorId = authorId;
            BookId = bookId;
        }
    }
}
