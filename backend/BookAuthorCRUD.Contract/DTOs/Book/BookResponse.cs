using BookAuthorCRUD.Contract.DTOs.Author;
using BookAuthorCRUD.Contract.DTOs.Genre;

namespace BookAuthorCRUD.Contract.DTOs.Book;

public record BookResponse(
    Guid Id,
    string Title,
    string Sypnosis,
    DateTime ReleaseDate,
    string Publisher,
    Guid GenreId
);
