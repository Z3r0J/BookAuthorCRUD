using BookAuthorCRUD.Contract.DTOs.Author;
using BookAuthorCRUD.Contract.DTOs.Book;

namespace BookAuthorCRUD.Contract.DTOs.Genre;

public record GenreResponse
{
    public GenreResponse()
    {

    }

    public Guid Id { get; init; }
    public string Name { get; init; }
    public List<BookResponse>? Books { get; init; }
    public long? BookCount { get; init; }
}
