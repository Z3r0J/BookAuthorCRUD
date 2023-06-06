using BookAuthorCRUD.Application.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Application.Feature.Author.Command.Delete
{
    internal class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Unit>
    {
        public readonly IAuthorService _authorService;

        public DeleteAuthorCommandHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<Unit> Handle(
            DeleteAuthorCommand request,
            CancellationToken cancellationToken
        )
        {
            await _authorService.Delete(request.Id);

            return Unit.Value;
        }
    }
}
