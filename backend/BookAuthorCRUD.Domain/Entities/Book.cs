using BookAuthorCRUD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Domain.Entities
{
    public sealed class Book : AuditableBaseEntity
    {
        public string Title { get; private set; } = string.Empty;
        public string Sypnosis { get;  private set; } = string.Empty;
        public DateTime ReleaseDate { get;  private set; } = DateTime.UtcNow;
        public string Publisher { get; private set; } = string.Empty;
        public Guid GenreId { get; private set; } = Guid.Empty;
        public Genre Genre { get; private set; } = new();

        public Guid AuthorId { get; private set; } = Guid.Empty;
        public Author Author { get; private set; } = new();

        public Book(string title, string sypnosis,DateTime releaseDate, string publisher, Guid genreId, Guid authorId,Author? author, Genre? genre)
        {
            Title= title;
            Sypnosis= sypnosis;
            ReleaseDate= releaseDate;
            Publisher= publisher;
            GenreId = genreId;
            AuthorId= authorId;
            Author = author??new Author();
            Genre = genre ?? new Genre();
        }

    }
}
