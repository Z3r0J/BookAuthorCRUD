using BookAuthorCRUD.Contract.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Contract.DTOs.Author;

public record BookAuthorResponse(
    Guid? Id,
    Guid? AuthorId,
    Guid? BookId
);
