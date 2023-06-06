using BookAuthorCRUD.Domain.Entities;
using BookAuthorCRUD.Domain.Interfaces;
using BookAuthorCRUD.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Infrastructure.Persistence.Repository;

public class BookRepository : IBookRepository
{
    private readonly ApplicationContext _applicationContext;

    public BookRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public void Add(Book book) => _applicationContext.Set<Book>().Add(book);

    public void Delete(Book book) => _applicationContext.Set<Book>().Remove(book);

    public async Task<List<Book>> GetAllBooks(CancellationToken cancellationToken = default) =>
        await _applicationContext
            .Set<Book>()
            .Include(x => x.Authors)
            .ThenInclude(x => x.Author)
            .Include(x => x.Genre)
            .AsSplitQuery()
            .ToListAsync(cancellationToken);

    public async Task<Book?> GetById(Guid id, CancellationToken cancellationToken = default) =>
        await _applicationContext
            .Set<Book>()
            .Include(x => x.Authors)
            .ThenInclude(x => x.Author)
            .Include(x => x.Genre)
            .AsSplitQuery()
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

    public async Task<List<Book>> GetBooksByAuthorId(
        Guid authorId,
        CancellationToken cancellationToken = default
    ) =>
        await _applicationContext
            .Set<Book>()
            .Include(x => x.Authors)
            .ThenInclude(x => x.Author)
            .Include(x => x.Genre)
            .Where(x => x.Authors.Any(x => x.AuthorId == authorId))
            .AsSplitQuery()
            .ToListAsync(cancellationToken);

    public void Update(Book book) => _applicationContext.Set<Book>().Update(book);
}
