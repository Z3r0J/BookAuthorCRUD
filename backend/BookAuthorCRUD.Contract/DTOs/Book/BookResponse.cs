using BookAuthorCRUD.Contract.DTOs.Author;
using BookAuthorCRUD.Contract.DTOs.Genre;

namespace BookAuthorCRUD.Contract.DTOs.Book;

public record BookResponse
{
    public BookResponse()
    {

    }

    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Sypnosis { get; init; }
    public DateTime ReleaseDate { get; init; }
    public string Publisher { get; init; }
    public Guid GenreId { get; init; }
    public string? GenreName { get; init; }
    public List<Dictionary<string,string>>? AuthorList { get; init; }
}
