using AutoMapper;
using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Author;
using BookAuthorCRUD.Contract.DTOs.Book;
using BookAuthorCRUD.Domain.Entities;
using BookAuthorCRUD.Domain.Interfaces;

namespace BookAuthorCRUD.Application.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AuthorService(IAuthorRepository authorRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AuthorResponse> Add(AuthorRequest authorRequest)
    {
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

        return _mapper.Map<AuthorResponse>(author);
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

    public async Task Update(Guid Id, AuthorRequest bookRequest)
    {
        var author = await _authorRepository.GetById(Id);

        if (author is null)
            throw new Exception("Book not found");

        author.Update(
            bookRequest.FirstName,
            bookRequest.LastName,
            bookRequest.Address,
            bookRequest.Email,
            bookRequest.BirthDate
            );

        await _unitOfWork.SaveChangesAsync();
    }
}
