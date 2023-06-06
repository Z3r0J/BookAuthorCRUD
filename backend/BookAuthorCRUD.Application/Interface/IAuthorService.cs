using BookAuthorCRUD.Contract.DTOs.Author;
using BookAuthorCRUD.Domain.Entities;
using LanguageExt.Common;

namespace BookAuthorCRUD.Application.Interface;

public interface IAuthorService
{
    Task <Result<AuthorResponse>> Add(AuthorRequest authorRequest);
    Task<Result<bool>> Update(Guid Id, AuthorRequest authorRequest);

    Task Delete(Guid id);

    Task<AuthorResponse> GetByIdAsync(Guid id);

    Task<List<AuthorResponse>> GetAllAsync();
}
