﻿using AutoMapper;
using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Author;
using BookAuthorCRUD.Domain.Entities;
using BookAuthorCRUD.Domain.Events.Author;
using BookAuthorCRUD.Domain.Exception;
using BookAuthorCRUD.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using LanguageExt.Common;
using MediatR;

namespace BookAuthorCRUD.Application.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<AuthorRequest> _authorValidator;
    private readonly IPublisher _publisher;

    public AuthorService(IAuthorRepository authorRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<AuthorRequest> authorValidator, IPublisher publisher)
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _authorValidator = authorValidator;
        _publisher = publisher;
    }

    public async Task<Result<AuthorResponse>> Add(AuthorRequest authorRequest)
    {
        var resultValidation = await _authorValidator.ValidateAsync(authorRequest);

        if (!resultValidation.IsValid) {

            var error = new ValidationException(resultValidation.Errors);

            return new Result<AuthorResponse>(error);
        }

        Author author = Author.Create(
            Guid.NewGuid(),
            authorRequest.FirstName,
            authorRequest.LastName,
            authorRequest.Address,
            authorRequest.Email,
            authorRequest.BirthDate
        );

        _authorRepository.Add(author);

        await _unitOfWork.SaveChangesAsync();

        await _publisher.Publish(new AuthorCreatedEvent(author));

        return new Result<AuthorResponse>(_mapper.Map<AuthorResponse>(author));
    }

    public async Task Delete(Guid id)
    {
        var author = await _authorRepository.GetById(id);

        if (author is null)
            throw new NotFoundException("Author was not found",id);

        _authorRepository.Delete(author);

        await _unitOfWork.SaveChangesAsync();

        await _publisher.Publish(new AuthorDeletedEvent(author));
    }

    public async Task<AuthorResponse> GetByIdAsync(Guid id)
    {
        var author = await _authorRepository.GetById(id);

        if (author is null)
            throw new NotFoundException("Author was not found",id);

        return _mapper.Map<AuthorResponse>(author);
    }

    public async Task<List<AuthorResponse>> GetAllAsync()
    {
        var authors = await _authorRepository.GetAllAuthor();

        return _mapper.Map<List<AuthorResponse>>(authors);
    }

    public async Task<Result<bool>> Update(Guid Id, AuthorRequest authorRequest)
    {
        var result = await _authorValidator.ValidateAsync(authorRequest);

        if(!result.IsValid)
        {
            var errors = new ValidationException(result.Errors);

            return new Result<bool>(errors);
        }

        var author = await _authorRepository.GetById(Id);

        if (author is null)
            throw new NotFoundException("Author was not found", authorRequest);

        author.Update(
            authorRequest.FirstName,
            authorRequest.LastName,
            authorRequest.Address,
            authorRequest.Email,
            authorRequest.BirthDate
            );

        _authorRepository.Update(author);

        await _unitOfWork.SaveChangesAsync();

        return new Result<bool>(true);
    }
}
