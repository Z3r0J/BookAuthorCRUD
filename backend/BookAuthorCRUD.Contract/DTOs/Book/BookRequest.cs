using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Contract.DTOs.Book;

public record BookRequest(
    string Title,
    string Sypnosis,
    DateTime ReleaseDate,
    string Publisher,
    Guid GenreId,
    List<Guid> AuthorsId
);
