using BookAuthorCRUD.Domain.Entities;
using BookAuthorCRUD.Domain.Interfaces;
using BookAuthorCRUD.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Infrastructure.Persistence.Repository
{
    public class BookAuthorRepository : IBookAuthorRepository
    {
        private readonly ApplicationContext _applicationContext;
        public BookAuthorRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public Task AddBookAuthor(BookAuthor bookAuthor, CancellationToken cancellationToken = default) => _applicationContext.Set<BookAuthor>().AddAsync(bookAuthor, cancellationToken).AsTask();

        public Task DeleteAuthors(Guid BookId, CancellationToken cancellationToken = default) => _applicationContext.Set<BookAuthor>().Where(x => x.BookId == BookId).ExecuteDeleteAsync(cancellationToken);
    }
}
