using BookAuthorCRUD.Contract.DTOs.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Application.Feature.Book.Query.GetAll;

public record GetAllBookQuery() : IRequest<IList<BookResponse>>;
