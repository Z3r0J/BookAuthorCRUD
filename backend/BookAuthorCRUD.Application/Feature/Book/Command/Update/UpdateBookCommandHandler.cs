using AutoMapper;
using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Book;
using LanguageExt.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Application.Feature.Book.Command.Update
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Result<bool>>
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        public async Task<Result<bool>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var bookToUpdate = _mapper.Map<BookRequest>(request);

            return await _bookService.Update(request.Id, bookToUpdate);
        }
    }
}
