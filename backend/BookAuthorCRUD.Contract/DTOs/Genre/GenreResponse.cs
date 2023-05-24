using BookAuthorCRUD.Contract.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Contract.DTOs.Genre;

public record GenreResponse(Guid Id, string Name, List<BookResponse> Books);
