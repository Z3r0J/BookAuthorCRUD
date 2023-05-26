using BookAuthorCRUD.Contract.DTOs.Book;

namespace BookAuthorCRUD.Contract.DTOs.Genre;

public record GenreResponse(Guid Id, string Name, List<BookResponse>? Books);
