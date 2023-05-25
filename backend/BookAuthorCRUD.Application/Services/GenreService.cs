using AutoMapper;
using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Book;
using BookAuthorCRUD.Contract.DTOs.Genre;
using BookAuthorCRUD.Domain.Entities;
using BookAuthorCRUD.Domain.Interfaces;

namespace BookAuthorCRUD.Application.Services;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GenreService(IGenreRepository genreRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _genreRepository = genreRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GenreResponse> Add(GenreRequest genreRequest)
    {
        Genre genre = Genre.Create(
            Guid.NewGuid(),
            genreRequest.Name
        );

        _genreRepository.Add(genre);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<GenreResponse>(genre);
    }

    public async Task Delete(Guid id)
    {
        var genre = await _genreRepository.GetById(id);

        if (genre is null)
            throw new Exception("Book not found");

        _genreRepository.Delete(genre);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<GenreResponse> GetByIdAsync(Guid id)
    {
        var genre = await _genreRepository.GetById(id);

        if (genre is null)
            throw new Exception("Genre not found");

        return _mapper.Map<GenreResponse>(genre);
    }

    public async Task<List<GenreResponse>> GetAllAsync()
    {
        var genres = await _genreRepository.GetAllGenres();

        if (!genres.Any())
            throw new Exception("No genres found");

        return _mapper.Map<List<GenreResponse>>(genres);
    }

    public async Task Update(Guid Id, GenreRequest genreRequest)
    {
        var genre = await _genreRepository.GetById(Id);

        if (genre is null)
            throw new Exception("Genre not found");

        genre.Update(
            genreRequest.Name
        );

        _genreRepository.Update(genre);

        await _unitOfWork.SaveChangesAsync();
    }
}
