using AutoMapper;
using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Author;
using LanguageExt.Common;
using MediatR;

namespace BookAuthorCRUD.Application.Feature.Author.Command;

class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Result<AuthorResponse>>
{
    private readonly IAuthorService _authorService;
    private readonly IMapper _mapper;

    public CreateAuthorCommandHandler(IAuthorService authorService, IMapper mapper)
    {
        _authorService = authorService;
        _mapper = mapper;
    }

    public async Task<Result<AuthorResponse>> Handle(
        CreateAuthorCommand request,
        CancellationToken cancellationToken
    )
    {
        var authorRequest = _mapper.Map<AuthorRequest>(request);

        return await _authorService.Add(authorRequest);
    }
}
