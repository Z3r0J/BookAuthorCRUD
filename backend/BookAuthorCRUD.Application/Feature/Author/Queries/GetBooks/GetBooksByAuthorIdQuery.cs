using BookAuthorCRUD.Contract.DTOs.Book;
using MediatR;

namespace BookAuthorCRUD.Application.Feature.Author.Queries.GetBooks;

public record GetBooksByAuthorIdQuery(Guid AuthorId) : IRequest<IList<BookResponse>>;
