using BookAuthorCRUD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Domain.Entities
{
    public class BookAuthor : AuditableBaseEntity
    {
        public Guid AuthorId { get; private set; } = Guid.Empty;
        public Author Author { get; private set; }

        public Guid BookId { get; private set; } = Guid.Empty;
        public Book Book { get; private set; }

        private BookAuthor(Guid authorId, Guid bookId)
        {
            AuthorId = authorId;
            BookId = bookId;
        }

        public static BookAuthor Create(Guid authorId, Guid bookId)
        {
            var bookAuthor = new BookAuthor(authorId, bookId);

            return bookAuthor;
        }

        public void Update(Guid authorId, Guid bookId)
        {
            AuthorId = authorId;
            BookId = bookId;
        }
    }
}
