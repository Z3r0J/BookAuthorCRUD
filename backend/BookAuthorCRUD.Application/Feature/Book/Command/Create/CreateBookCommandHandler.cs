using AutoMapper;
using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Book;
using LanguageExt.Common;
using MediatR;

namespace BookAuthorCRUD.Application.Feature.Book.Command.Create;

internal class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Result<BookResponse>>
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;

    public CreateBookCommandHandler(IBookService bookService, IMapper mapper)
    {
        _bookService = bookService;
        _mapper = mapper;
    }

    public async Task<Result<BookResponse>> Handle(
        CreateBookCommand request,
        CancellationToken cancellationToken
    )
    {
        var bookToCreate = _mapper.Map<BookRequest>(request);

        return await _bookService.Add(bookToCreate);
    }
}
