using BookAuthorCRUD.Application.Interface;
using MediatR;

namespace BookAuthorCRUD.Application.Feature.Genre.Command.Delete;

internal class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, Unit>
{
    private readonly IGenreService _genreService;

    public DeleteGenreCommandHandler(IGenreService genreService)
    {
        _genreService = genreService;
    }

    public async Task<Unit> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        await _genreService.Delete(request.Id);

        return Unit.Value;
    }
}
