using AutoMapper;
using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Genre;
using LanguageExt.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Application.Feature.Genre.Command.Create;

internal class CreateGenreCommandHandler
    : IRequestHandler<CreateGenreCommand, Result<GenreResponse>>
{
    private readonly IGenreService _genreService;
    private readonly IMapper _mapper;

    public CreateGenreCommandHandler(IGenreService genreService, IMapper mapper)
    {
        _genreService = genreService;
        _mapper = mapper;
    }

    public async Task<Result<GenreResponse>> Handle(
        CreateGenreCommand request,
        CancellationToken cancellationToken
    )
    {
        var genreToCreate = _mapper.Map<GenreRequest>(request);
        return await _genreService.Add(genreToCreate);
    }
}
