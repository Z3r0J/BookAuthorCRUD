using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Contract.DTOs.Author;

public record AuthorResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Address,
    string Email,
    DateTime BirthDate,
    List<Book> Books
);
