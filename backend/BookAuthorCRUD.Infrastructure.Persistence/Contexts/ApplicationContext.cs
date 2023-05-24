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

        //Fluent API
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
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .Entity<Author>()
                .HasMany(x => x.Books)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
            ;
            builder
                .Entity<Genre>()
                .HasMany(x => x.Books)
                .WithOne(x => x.Genre)
                .HasForeignKey(x => x.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
            ;
            #endregion

            #region Properties

            #region Book Property

            builder.Entity<Book>().Property(x => x.Sypnosis).IsRequired();
            builder
                .Entity<Book>()
                .Property(x => x.Publisher)
                .HasColumnName("PublishedBy")
                .IsRequired();
            builder
                .Entity<Book>()
                .Property(x => x.ReleaseDate)
                .HasColumnName("ReleaseOn")
                .IsRequired();

            #endregion

            #region Author

            builder.Entity<Author>().Property(x => x.Address).IsRequired();
            builder.Entity<Author>().Property(x => x.Email).IsRequired();
            builder.Entity<Author>().Property(x => x.FirstName).IsRequired();
            builder.Entity<Author>().Property(x => x.LastName).IsRequired();
            builder.Entity<Author>().Property(x => x.BirthDate).IsRequired();

            #endregion

            #region Genre

            builder.Entity<Genre>().Property(x => x.Name).IsRequired();

            #endregion

            #endregion

            base.OnModelCreating(builder);
        }
    }
}
