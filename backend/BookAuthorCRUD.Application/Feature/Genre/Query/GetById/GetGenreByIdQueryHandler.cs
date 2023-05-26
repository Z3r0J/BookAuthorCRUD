using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Genre;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Application.Feature.Genre.Query.GetById;

internal class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, GenreResponse>
{
    private readonly IGenreService _genreService;

    public GetGenreByIdQueryHandler(IGenreService genreService)
    {
        _genreService = genreService;
    }

    public async Task<GenreResponse> Handle(
        GetGenreByIdQuery request,
        CancellationToken cancellationToken
    ) => await _genreService.GetByIdAsync(request.Id);
}
