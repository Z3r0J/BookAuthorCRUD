using BookAuthorCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Test.Domain.Test
{
    public class BookTest
    {


        [Fact]

        public void ShouldCreateBookUsingEmptyConstructor()
        {
            // Arrange
            var book = new Book();

            // Act

            // Assert
            Assert.IsType<Book>(book);
        }

        [Fact]

        public void ShouldCreateANewBook()
        {
            // Arrange

            var book = new
            {
                Id = Guid.NewGuid(),
                Title = "The Lord of the Rings",
                Sypnosis = "The Lord of the Rings is an epic high fantasy novel by the English author and scholar J. R. R. Tolkien.",
                ReleaseDate = DateTime.Now.AddYears(-18),
                Publisher = "HarperCollins",
                GenreId = Guid.NewGuid()
            };

            // Act

            var result = Book.Create(
                book.Id,
                book.Title,
                book.Sypnosis,
                book.ReleaseDate,
                book.Publisher,
                book.GenreId
                );

            // Assert

            Assert.IsType<Book>(result);
            Assert.Equal(book.Id, result.Id);
        }

        [Fact]
        public void ShouldAddAuthorsToTheBook()
        {
            // Arrange

            var book = new
            {
                Id = Guid.NewGuid(),
                Title = "The Lord of the Rings",
                Sypnosis = "The Lord of the Rings is an epic high fantasy novel by the English author and scholar J. R. R. Tolkien.",
                ReleaseDate = DateTime.Now.AddYears(-18),
                Publisher = "HarperCollins",
                GenreId = Guid.NewGuid()
            };

            var bookAuthor = new
            {
                Id = Guid.NewGuid(),
                BookId = book.Id,
                AuthorId = Guid.NewGuid()
            };

            // Act

            var result = Book.Create(
                book.Id,
                book.Title,
                book.Sypnosis,
                book.ReleaseDate,
                book.Publisher,
                book.GenreId
                );

            result.AddAuthor(BookAuthor.Create(bookAuthor.AuthorId,bookAuthor.BookId));

            // Assert

            Assert.True(result.Authors.Any());
            Assert.Equal(bookAuthor.AuthorId, result.Authors.FirstOrDefault()!.AuthorId);

        }

        [Theory]
        [InlineData("The Lord of The Rings II")]
        [InlineData("Harry Potter")]
        [InlineData("The Hobbit")]
        public void ShouldUpdateExistingBook(string TitleToUpdate)
        {
            // Arrange
            var book = new
            {
                Id = Guid.NewGuid(),
                Title = "The Lord of the Rings",
                Sypnosis = "The Lord of the Rings is an epic high fantasy novel by the English author and scholar J. R. R. Tolkien.",
                ReleaseDate = DateTime.Now.AddYears(-18),
                Publisher = "HarperCollins",
                GenreId = Guid.NewGuid()
            };

            // Act

            var result = Book.Create(

                book.Id,
                book.Title,
                book.Sypnosis,
                book.ReleaseDate,
                book.Publisher,
                book.GenreId
                );

            result.Update(TitleToUpdate);

            // Assert

            Assert.Equal(TitleToUpdate, result.Title);
            Assert.Contains(TitleToUpdate, result.Title);

        }
    }
}
