using AutoMapper;
using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Author;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Application.Feature.Author.Queries;

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
