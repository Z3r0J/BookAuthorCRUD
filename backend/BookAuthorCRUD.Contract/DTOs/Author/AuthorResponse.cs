using BookAuthorCRUD.Contract.DTOs.Book;

namespace BookAuthorCRUD.Contract.DTOs.Author;

public record AuthorResponse
{
    public AuthorResponse()
    {

    }

    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Address { get; init; }
    public string Email { get; init; }
    public DateTime BirthDate { get; init; }
    public IReadOnlyCollection<BookAuthorResponse>? Books { get; init; }
    public long? BookCount { get; init; }
}
