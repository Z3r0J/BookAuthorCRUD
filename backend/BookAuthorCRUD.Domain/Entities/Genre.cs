using BookAuthorCRUD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Domain.Entities
{
    public sealed class Genre : AuditableBaseEntity
    {
        private readonly List<Book> _books = new();
        public string Name { get; private set; } = string.Empty;
        public IReadOnlyCollection<Book> Books => _books;

        public Genre() { }

        private Genre(Guid id,string name)
        {
            Id = id;
            Name = name;
        }

        public static Genre Create(Guid id, string name)
        {
            var genre = new Genre(id, name);

            return genre;
        }

        public void Update(string? name =null)
        {
            Name = name??Name;
        }

        public void AddBooks(Book book)
        {
            _books.Add(book);
        }

    }
}
