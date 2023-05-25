using BookAuthorCRUD.Contract.DTOs.Author;
using BookAuthorCRUD.Contract.DTOs.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Contract.DTOs.Book;

public record BookResponse(
    Guid Id,
    string Title,
    string Sypnosis,
    DateTime ReleaseDate,
    string Publisher,
    Guid GenreId,
    GenreResponse Genre,
    List<AuthorResponse>? Authors
);
