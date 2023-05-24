using BookAuthorCRUD.Domain.Common;
using BookAuthorCRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                _ = entry.State switch
                {
                    EntityState.Modified => () => entry.Entity.UpdatedAt = DateTime.UtcNow,
                    EntityState.Added => () => entry.Entity.CreatedAt = DateTime.UtcNow,

                    _ => new Action(() => { })
                };
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Tables and Primary Key
            builder.Entity<Book>().ToTable("Books").HasKey(x => x.Id);
            builder.Entity<Author>().ToTable("Authors").HasKey(x => x.Id);
            builder.Entity<Genre>().ToTable("Genres").HasKey(x => x.Id);
            builder.Entity<BookAuthor>().ToTable("Books_Authors").HasKey(x => x.Id);
            #endregion

            #region RelationShip Between Tables
            builder
                .Entity<Book>()
                .HasMany(x => x.Authors)
                .WithOne(x => x.Book)
                .HasForeignKey(x => x.BookId);
            builder
                .Entity<Author>()
                .HasMany(x => x.Books)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId);
            builder
                .Entity<Genre>()
                .HasMany(x => x.Books)
                .WithOne(x => x.Genre)
                .HasForeignKey(x => x.GenreId);
            #endregion

            #region Properties

            #region Book Property

            builder.Entity<Book>().Property(x => x.Sypnosis).HasColumnName("Sypnosis").IsRequired();

            #endregion

            #endregion


            #region Set Value through the Constructor

            builder.Entity<Book>().


            #endregion


            base.OnModelCreating(builder);
        }
    }
}
