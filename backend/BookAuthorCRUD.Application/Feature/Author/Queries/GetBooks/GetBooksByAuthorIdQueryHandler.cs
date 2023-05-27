using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Application.Feature.Author.Queries.GetBooks
{
    internal class GetBooksByAuthorIdQueryHandler : IRequestHandler<GetBooksByAuthorIdQuery, IList<BookResponse>>
    {
        private readonly IBookService _bookService;

        public GetBooksByAuthorIdQueryHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IList<BookResponse>> Handle(GetBooksByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            return await _bookService.GetBooksByAuthorId(request.AuthorId);
        }
    }
}
