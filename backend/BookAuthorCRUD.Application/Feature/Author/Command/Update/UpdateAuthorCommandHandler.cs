using AutoMapper;
using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Author;
using LanguageExt.Common;
using MediatR;

namespace BookAuthorCRUD.Application.Feature.Author.Command.Update
{
    internal class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Result<bool>>
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        public async Task<Result<bool>> Handle(
            UpdateAuthorCommand request,
            CancellationToken cancellationToken
        )
        {
            var authorToUpdate = _mapper.Map<AuthorRequest>(request);

            return await _authorService.Update(request.Id, authorToUpdate);
        }
    }
}
