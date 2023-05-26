using BookAuthorCRUD.Contract.DTOs.Book;

namespace BookAuthorCRUD.Contract.DTOs.Author;

public record AuthorResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Address,
    string Email,
    DateTime BirthDate,
    IReadOnlyCollection<BookAuthorResponse>? Books
);
