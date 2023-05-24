using BookAuthorCRUD.Contract.DTOs.Author;
using BookAuthorCRUD.Domain.Entities;

namespace BookAuthorCRUD.Application.Interface;

public interface IAuthorService
{
    Task <AuthorResponse> Add(AuthorRequest authorRequest);
    Task Update(Guid Id, AuthorRequest authorRequest);

    Task Delete(Guid id);

    Task<AuthorResponse> GetByIdAsync(Guid id);

    Task<List<AuthorResponse>> GetAllAsync();
}
