using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Application.Feature.Book.Query.GetById;

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookResponse>
{
    private readonly IBookService _bookService;

    public GetBookByIdQueryHandler(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<BookResponse> Handle(
        GetBookByIdQuery request,
        CancellationToken cancellationToken
    ) => await _bookService.GetByIdAsync(request.Id);
}
