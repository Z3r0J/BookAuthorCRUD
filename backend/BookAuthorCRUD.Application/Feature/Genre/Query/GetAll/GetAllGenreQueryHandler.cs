using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Genre;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Application.Feature.Genre.Query.GetAll;
internal class GetAllGenreQueryHandler : IRequestHandler<GetAllGenreQuery, IList<GenreResponse>>
{
    private readonly IGenreService _genreService;

    public GetAllGenreQueryHandler(IGenreService genreService)
    {
        _genreService = genreService;
    }

    public async Task<IList<GenreResponse>> Handle(GetAllGenreQuery request, CancellationToken cancellationToken)
    {
        return await _genreService.GetAllAsync();
    }
}
