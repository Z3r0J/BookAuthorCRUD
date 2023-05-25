using AutoMapper;
using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Book;
using BookAuthorCRUD.Domain.Entities;
using BookAuthorCRUD.Domain.Interfaces;

namespace BookAuthorCRUD.Application.Services;

public class BookServices : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookServices(IBookRepository bookRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BookResponse> Add(BookRequest bookRequest)
    {
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

    public async Task Update(Guid Id, BookRequest bookRequest)
    {
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
    }
}
