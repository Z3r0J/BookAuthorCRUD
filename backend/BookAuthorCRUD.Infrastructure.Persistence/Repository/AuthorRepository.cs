﻿using BookAuthorCRUD.Domain.Entities;
using BookAuthorCRUD.Domain.Interfaces;
using BookAuthorCRUD.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Infrastructure.Persistence.Repository;

public class AuthorRepository : IAuthorRepository
{
    private readonly ApplicationContext _applicationContext;

    public AuthorRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public void Add(Author author) => _applicationContext.Set<Author>().Add(author);

    public void Delete(Author author) => _applicationContext.Set<Author>().Remove(author);

    public async Task<List<Author>> GetAllAuthor(CancellationToken cancellationToken = default) =>
        await _applicationContext
            .Set<Author>()
            .Include(x => x.Books)
            .ThenInclude(x => x.Book!)
            .ThenInclude(x => x.Genre)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    public async Task<Author?> GetById(Guid id, CancellationToken cancellationToken = default) =>
        await _applicationContext
            .Set<Author>()
            .Include(x => x.Books)
            .ThenInclude(x => x.Book!)
            .ThenInclude(x => x.Genre)
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

    public void Update(Author author) => _applicationContext.Set<Author>().Update(author);

    public async Task<List<Guid>> ExistAuthor(
        List<Guid> authorIds,
        CancellationToken cancellationToken = default
    ) =>
        await _applicationContext
            .Set<Author>()
            .Where(x => authorIds.Contains(x.Id))
            .Select(x => x.Id)
            .ToListAsync(cancellationToken);
}
