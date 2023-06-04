using BookAuthorCRUD.Domain.Common;

namespace BookAuthorCRUD.Domain.Entities
{
    public sealed class Book : AuditableBaseEntity
    {
        private readonly List<BookAuthor> _bookAuthors = new();

        public string Title { get; private set; } = string.Empty;
        public string Sypnosis { get; private set; } = string.Empty;
        public DateTime ReleaseDate { get; private set; } = DateTime.UtcNow;
        public string Publisher { get; private set; } = string.Empty;
        public Guid GenreId { get; private set; } = Guid.Empty;
        public Genre Genre { get; private set; }
        public IReadOnlyCollection<BookAuthor> Authors => _bookAuthors;

        public Book() { }
        private Book(
            Guid id,
            string title,
            string sypnosis,
            DateTime releaseDate,
            string publisher,
            Guid genreId
        )
        {
            Id = id;
            Title = title;
            Sypnosis = sypnosis;
            ReleaseDate = releaseDate;
            Publisher = publisher;
            GenreId = genreId;
        }

        public static Book Create(
            Guid id,
            string title,
            string sypnosis,
            DateTime releaseDate,
            string publisher,
            Guid genreId
        )
        {
            var book = new Book(id, title, sypnosis, releaseDate, publisher, genreId);

            return book;
        }

        public void Update(
            string? title = null,
            string? sypnosis = null,
            DateTime releaseDate = default,
            string? publisher = null,
            Guid? genreId = null
        )
        {
            Title = title ?? Title;
            Sypnosis = sypnosis ?? Sypnosis;
            ReleaseDate = releaseDate;
            Publisher = publisher??Publisher;
            GenreId = genreId??GenreId;
        }

        public void AddAuthor(BookAuthor bookAuthor)
        {
            _bookAuthors.Add(bookAuthor);
        }
        public void RemoveAuthor()
        {
            for (int i = _bookAuthors.Count - 1; i >= 0; i--)
            {
                _bookAuthors.RemoveAt(i);
            }
        }
    }
}
