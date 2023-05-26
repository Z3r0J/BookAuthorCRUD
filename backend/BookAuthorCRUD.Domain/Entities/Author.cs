using BookAuthorCRUD.Domain.Common;

namespace BookAuthorCRUD.Domain.Entities;

public sealed class Author : AuditableBaseEntity
{
    private readonly List<BookAuthor> _bookAuthors = new();

    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Address { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public DateTime BirthDate { get; private set; } = DateTime.UtcNow;
    public IReadOnlyCollection<BookAuthor> Books => _bookAuthors;

    private Author(
        Guid id,
        string firstName,
        string lastName,
        string address,
        string email,
        DateTime birthDate
    )
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Email = email;
        BirthDate = birthDate;
    }

    public void AddBooks(BookAuthor book)
    {
        _bookAuthors.Add(book);
    }

    public static Author Create(
        Guid id,
        string firstName,
        string lastName,
        string address,
        string email,
        DateTime birthDate
    )
    {
        var author = new Author(id, firstName, lastName, address, email, birthDate);

        return author;
    }

    public void Update(
        string firstName,
        string lastName,
        string address,
        string email,
        DateTime birthDate
    )
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Email = email;
        BirthDate = birthDate;
    }
}
