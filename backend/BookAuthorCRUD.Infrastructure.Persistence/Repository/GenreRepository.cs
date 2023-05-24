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

public class GenreRepository : IGenreRepository
{
    private readonly ApplicationContext _applicationContext;

    public GenreRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public void Add(Genre genre) => _applicationContext.Set<Genre>().Add(genre);

    public void Delete(Genre genre) => _applicationContext.Set<Genre>().Remove(genre);

    public async Task<List<Genre>> GetAllGenres(CancellationToken cancellationToken = default) =>
        await _applicationContext
            .Set<Genre>()
            .Include(x => x.Books)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    public async Task<Genre?> GetById(Guid id, CancellationToken cancellationToken = default) =>
        await _applicationContext
            .Set<Genre>()
            .Include(x => x.Books)
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

    public void Update(Genre genre) => _applicationContext.Set<Genre>().Update(genre);
}
