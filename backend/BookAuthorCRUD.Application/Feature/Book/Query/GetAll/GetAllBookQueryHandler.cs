using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Book;
using MediatR;

namespace BookAuthorCRUD.Application.Feature.Book.Query.GetAll;

internal class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery, IList<BookResponse>>
{
    private readonly IBookService _bookService;

    public GetAllBookQueryHandler(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<IList<BookResponse>> Handle(
        GetAllBookQuery request,
        CancellationToken cancellationToken
    ) => await _bookService.GetAllAsync();
}
