using AutoMapper;
using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Author;
using BookAuthorCRUD.Domain.Entities;
using BookAuthorCRUD.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using LanguageExt.Common;

namespace BookAuthorCRUD.Application.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<AuthorRequest> _authorValidator;

    public AuthorService(IAuthorRepository authorRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<AuthorRequest> authorValidator)
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _authorValidator = authorValidator;
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

        return new Result<AuthorResponse>(_mapper.Map<AuthorResponse>(author));
    }

    public async Task Delete(Guid id)
    {
        var book = await _authorRepository.GetById(id);

        if (book is null)
            throw new Exception("Book not found");

        _authorRepository.Delete(book);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<AuthorResponse> GetByIdAsync(Guid id)
    {
        var author = await _authorRepository.GetById(id);

        if (author is null)
            throw new Exception("Book not found");

        return _mapper.Map<AuthorResponse>(author);
    }

    public async Task<List<AuthorResponse>> GetAllAsync()
    {
        var authors = await _authorRepository.GetAllAuthor();

        if (!authors.Any())
            throw new Exception("No books found");

        return _mapper.Map<List<AuthorResponse>>(authors);
    }

    public async Task<Result<bool>> Update(Guid Id, AuthorRequest bookRequest)
    {
        var result = await _authorValidator.ValidateAsync(bookRequest);

        if(!result.IsValid)
        {
            var errors = new ValidationException(result.Errors);

            return new Result<bool>(errors);
        }

        var author = await _authorRepository.GetById(Id);

        if (author is null)
            return new Result<bool>(new ValidationException("Books not found"));

        author.Update(
            bookRequest.FirstName,
            bookRequest.LastName,
            bookRequest.Address,
            bookRequest.Email,
            bookRequest.BirthDate
            );

        await _unitOfWork.SaveChangesAsync();

        return new Result<bool>(true);
    }
}
