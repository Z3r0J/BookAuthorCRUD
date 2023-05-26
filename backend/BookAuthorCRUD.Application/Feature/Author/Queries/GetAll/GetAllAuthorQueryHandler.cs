using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Author;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Application.Feature.Author.Queries.GetAll;
internal class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQuery, IList<AuthorResponse>>
{

    private readonly IAuthorService _authorService;

    public GetAllAuthorQueryHandler(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    public async Task<IList<AuthorResponse>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
    {
        return await _authorService.GetAllAsync();
    }
}
