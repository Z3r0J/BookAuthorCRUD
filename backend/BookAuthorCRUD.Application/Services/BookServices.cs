using AutoMapper;
using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Book;
using BookAuthorCRUD.Domain.Entities;
using BookAuthorCRUD.Domain.Events.Book;
using BookAuthorCRUD.Domain.Exception;
using BookAuthorCRUD.Domain.Interfaces;
using FluentValidation;
using LanguageExt;
using LanguageExt.Common;
using MediatR;

namespace BookAuthorCRUD.Application.Services;

public class BookServices : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IBookAuthorRepository _bookAuthorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<BookRequest> _bookValidator;
    private readonly IPublisher _publisher;

    public BookServices(IBookRepository bookRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<BookRequest> bookValidator, IAuthorRepository authorRepository, IBookAuthorRepository bookAuthorRepository, IPublisher publisher)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _bookValidator = bookValidator;
        _authorRepository = authorRepository;
        _bookAuthorRepository = bookAuthorRepository;
        _publisher = publisher;
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

        if (bookRequest.AuthorsId.Any()) {
            var authorsId = await _authorRepository.ExistAuthor(bookRequest.AuthorsId);

            if (authorsId.Count == 0)
                throw new NotFoundException("Authors not found",bookRequest.AuthorsId);

            authorsId
                .Select(authorId => BookAuthor.Create(authorId, book.Id))
                .ToList()
                .ForEach(bookAuthor => book.AddAuthor(bookAuthor));
        }

        _bookRepository.Add(book);

        await _unitOfWork.SaveChangesAsync();

        await _publisher.Publish(new BookCreatedEvent(book));

        return new Result<BookResponse>(_mapper.Map<BookResponse>(book));
    }

    public async Task Delete(Guid id)
    {
        var book = await _bookRepository.GetById(id);

        if (book is null)
            throw new NotFoundException("Book not found", id);

        _bookRepository.Delete(book);

        await _unitOfWork.SaveChangesAsync();

        await _publisher.Publish(new BookDeletedEvent(book));
    }

    public async Task<BookResponse> GetByIdAsync(Guid id)
    {
        var book = await _bookRepository.GetById(id);

        if (book is null)
            throw new NotFoundException("Book not found", id);

        return _mapper.Map<BookResponse>(book);
    }

    public async Task<List<BookResponse>> GetAllAsync()
    {
        var books = await _bookRepository.GetAllBooks();

        return _mapper.Map<List<BookResponse>>(books);
    }

    public async Task<List<BookResponse>> GetBooksByAuthorId(Guid authorId)
    {
        var books = await _bookRepository.GetBooksByAuthorId(authorId);

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


        if (bookRequest.AuthorsId.Any())
        { 
            var authorsId = await _authorRepository.ExistAuthor(bookRequest.AuthorsId);

            if (authorsId.Count == 0)
                throw new NotFoundException("Authors not found",bookRequest.AuthorsId);

            await _bookAuthorRepository.DeleteAuthors(Id);

            authorsId
                .Select(authorId => BookAuthor.Create(authorId, Id))
                .ToList()
                .ForEach(bookAuthor => _bookAuthorRepository.AddBookAuthor(bookAuthor));
        }

        var book = await _bookRepository.GetById(Id);

        if (book is null)
            throw new NotFoundException("Book not found",Id);

        book.Update(
            bookRequest.Title,
            bookRequest.Sypnosis,
            bookRequest.ReleaseDate,
            bookRequest.Publisher,
            bookRequest.GenreId
        );

        _bookRepository.Update(book);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
