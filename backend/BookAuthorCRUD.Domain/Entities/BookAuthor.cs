using BookAuthorCRUD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Domain.Entities
{
    public class BookAuthor: AuditableBaseEntity
    {
        public Guid AuthorId { get; private set; } = Guid.Empty;
        public Author Author { get; private set; } = new Author();

        public Guid BookId { get; private set; } = Guid.Empty;
        public Book Book { get; private set; } = new Book();

        public BookAuthor()
        {

        }

        public BookAuthor(Guid authorId, Guid bookId, Author? author,Book? book)
        {
            AuthorId = authorId;
            Author = author ?? new();
            BookId = bookId;
            Book = book?? new();
        }
    }
}
