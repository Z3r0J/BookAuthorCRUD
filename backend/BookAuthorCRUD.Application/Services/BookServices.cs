using AutoMapper;
using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Book;
using BookAuthorCRUD.Domain.Entities;
using BookAuthorCRUD.Domain.Interfaces;
using FluentValidation;
using LanguageExt.Common;

namespace BookAuthorCRUD.Application.Services;

public class BookServices : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<BookRequest> _bookValidator;

    public BookServices(IBookRepository bookRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<BookRequest> bookValidator)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _bookValidator = bookValidator;
    }

    public async Task<Result<BookResponse>> Add(BookRequest bookRequest)
    {
        var resultValidator = await _bookValidator.ValidateAsync(bookRequest);

        if (!resultValidator.IsValid)
        {
            var errors = new ValidationException(resultValidator.Errors);

            return new Result<BookResponse>(errors);
        }

        Book book = Book.Create(
            Guid.NewGuid(),
            bookRequest.Title,
            bookRequest.Sypnosis,
            bookRequest.ReleaseDate,
            bookRequest.Publisher,
            bookRequest.GenreId
        );

        if (bookRequest.AuthorsId.Any())
            bookRequest.AuthorsId
                .Select(authorId => BookAuthor.Create(authorId, book.Id))
                .ToList()
                .ForEach(bookAuthor => book.AddAuthor(bookAuthor));

        _bookRepository.Add(book);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<BookResponse>(book);
    }

    public async Task Delete(Guid id)
    {
        var book = await _bookRepository.GetById(id);

        if (book is null)
            throw new Exception("Book not found");

        _bookRepository.Delete(book);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<BookResponse> GetByIdAsync(Guid id)
    {
        var book = await _bookRepository.GetById(id);

        if (book is null)
            throw new Exception("Book not found");

        return _mapper.Map<BookResponse>(book);
    }

    public async Task<List<BookResponse>> GetAllAsync()
    {
        var books = await _bookRepository.GetAllBooks();

        if (!books.Any())
            throw new Exception("No books found");

        return _mapper.Map<List<BookResponse>>(books);
    }

    public async Task<Result<bool>> Update(Guid Id, BookRequest bookRequest)
    {
        var resultValidator = await _bookValidator.ValidateAsync(bookRequest);

        if (!resultValidator.IsValid)
        {
            var errors = new ValidationException(resultValidator.Errors);

            return new Result<bool>(errors);
        }

        var book = await _bookRepository.GetById(Id);

        if (book is null)
            throw new Exception("Book not found");

        book.Update(
            bookRequest.Title,
            bookRequest.Sypnosis,
            bookRequest.ReleaseDate,
            bookRequest.Publisher,
            bookRequest.GenreId
        );

        if (bookRequest.AuthorsId.Any())
        {
            book.RemoveAuthor();

            bookRequest.AuthorsId
                .Select(authorId => BookAuthor.Create(authorId, book.Id))
                .ToList()
                .ForEach(bookAuthor => book.AddAuthor(bookAuthor));
        }

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
