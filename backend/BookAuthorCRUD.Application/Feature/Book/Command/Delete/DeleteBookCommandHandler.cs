using BookAuthorCRUD.Application.Interface;
using LanguageExt.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Application.Feature.Book.Command.Delete;
internal class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
{
    private readonly IBookService _bookService;

    public DeleteBookCommandHandler(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        await _bookService.Delete(request.Id);

        return Unit.Value;
    }
}
