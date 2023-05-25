using BookAuthorCRUD.Contract.DTOs.Book;
using BookAuthorCRUD.Domain.Entities;
using LanguageExt.Common;

namespace BookAuthorCRUD.Application.Interface;

public interface IBookService
{
    Task <Result<BookResponse>> Add(BookRequest bookRequest);
    Task<Result<bool>> Update(Guid Id, BookRequest bookRequest);

    Task Delete(Guid id);

    Task<BookResponse> GetByIdAsync(Guid id);

    Task<List<BookResponse>> GetAllAsync();
}
