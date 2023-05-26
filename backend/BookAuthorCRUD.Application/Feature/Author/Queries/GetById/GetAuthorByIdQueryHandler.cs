using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Author;
using MediatR;

namespace BookAuthorCRUD.Application.Feature.Author.Queries.GetById;

public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorResponse>
{
    private readonly IAuthorService _authorService;

    public GetAuthorByIdQueryHandler(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    public async Task<AuthorResponse> Handle(
        GetAuthorByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        return await _authorService.GetByIdAsync(request.Id);
    }
}
