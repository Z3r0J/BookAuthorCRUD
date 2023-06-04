﻿using AutoMapper;
using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Genre;
using BookAuthorCRUD.Domain.Entities;
using BookAuthorCRUD.Domain.Events.Genre;
using BookAuthorCRUD.Domain.Exception;
using BookAuthorCRUD.Domain.Interfaces;
using FluentValidation;
using LanguageExt.Common;
using MediatR;

namespace BookAuthorCRUD.Application.Services;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<GenreRequest> _genreValidator;
    private readonly IPublisher _publisher;

    public GenreService(IGenreRepository genreRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<GenreRequest> genreValidator, IPublisher publisher)
    {
        _genreRepository = genreRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _genreValidator = genreValidator;
        _publisher = publisher;
    }

    public async Task<Result<GenreResponse>> Add(GenreRequest genreRequest)
    {
        var resultValidation = await _genreValidator.ValidateAsync(genreRequest);

        if (!resultValidation.IsValid)
        {
            var errors = new ValidationException(resultValidation.Errors);

            return new Result<GenreResponse>(errors);
        }

        Genre genre = Genre.Create(
            Guid.NewGuid(),
            genreRequest.Name
        );

        _genreRepository.Add(genre);

        await _unitOfWork.SaveChangesAsync();

        await _publisher.Publish(new GenreCreatedEvent(genre));

        return _mapper.Map<GenreResponse>(genre);
    }

    public async Task Delete(Guid id)
    {
        var genre = await _genreRepository.GetById(id);

        if (genre is null)
            throw new NotFoundException("Genre not found",id);

        _genreRepository.Delete(genre);

        await _unitOfWork.SaveChangesAsync();

        await _publisher.Publish(new GenreDeletedEvent(genre));
    }

    public async Task<GenreResponse> GetByIdAsync(Guid id)
    {
        var genre = await _genreRepository.GetById(id);

        if (genre is null)
            throw new NotFoundException("Genre not found", id);

        return _mapper.Map<GenreResponse>(genre);
    }

    public async Task<List<GenreResponse>> GetAllAsync()
    {
        var genres = await _genreRepository.GetAllGenres();

        return _mapper.Map<List<GenreResponse>>(genres);
    }

    public async Task<Result<bool>> Update(Guid Id, GenreRequest genreRequest)
    {
        var resultValidation = await _genreValidator.ValidateAsync(genreRequest);

        if (!resultValidation.IsValid)
        {
            var errors = new ValidationException(resultValidation.Errors);

            return new Result<bool>(errors);
        }

        var genre = await _genreRepository.GetById(Id);

        if (genre is null)
            throw new NotFoundException("Genre not found",genreRequest);

        genre.Update(
            genreRequest.Name
        );

        _genreRepository.Update(genre);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
