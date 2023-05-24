using BookAuthorCRUD.Contract.DTOs.Book;
using BookAuthorCRUD.Domain.Entities;

namespace BookAuthorCRUD.Application.Interface;

public interface IBookService
{
    Task <BookResponse> Add(BookRequest bookRequest);
    Task Update(Guid Id, BookRequest bookRequest);

    Task Delete(Guid id);

    Task<BookResponse> GetByIdAsync(Guid id);

    Task<List<BookResponse>> GetAllAsync();
}
