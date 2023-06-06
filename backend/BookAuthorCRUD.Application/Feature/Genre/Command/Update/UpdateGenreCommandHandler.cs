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

namespace BookAuthorCRUD.Application.Feature.Genre.Command.Update
{
    internal class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, Result<bool>>
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public UpdateGenreCommandHandler(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        public async Task<Result<bool>> Handle(
            UpdateGenreCommand request,
            CancellationToken cancellationToken
        )
        {
            var genreToUpdate = _mapper.Map<GenreRequest>(request);

            return await _genreService.Update(request.Id, genreToUpdate);
        }
    }
}
