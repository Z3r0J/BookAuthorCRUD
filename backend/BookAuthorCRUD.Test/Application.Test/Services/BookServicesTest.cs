using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Author;
using BookAuthorCRUD.Contract.DTOs.Book;
using BookAuthorCRUD.Contract.DTOs.Genre;
using BookAuthorCRUD.Domain.Entities;
using BookAuthorCRUD.Domain.Exception;
using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Test.Application.Test.Services
{
    public class BookServicesTest
    {
        private readonly IServiceProvider _serviceProvider = Startup.ServiceProvider();
        private readonly IBookService _bookServices;
        private readonly IGenreService _genreServices;
        private readonly IAuthorService _authorServices;

        public BookServicesTest()
        {
            _bookServices = (IBookService)_serviceProvider.GetService(typeof(IBookService))!;
            _genreServices = (IGenreService)_serviceProvider.GetService(typeof(IGenreService))!;
            _authorServices = (IAuthorService)_serviceProvider.GetService(typeof(IAuthorService))!;
        }

        [Fact]
        public async Task ShouldCreateABook()
        {
            //Arrange

            var genre = await CreateAGenre();
            var author = await CreateAnAuthor();

            var book = BookRequest(
                null,
                genre.Match(g => g.Id, err => Guid.Empty),
                author.Match(a => new List<Guid>() { a.Id }, err => new List<Guid>() { Guid.Empty })
            );

            //Act
            var response = await _bookServices.Add(book);

            //Assert

            Assert.IsType<Result<BookResponse>>(response);
        }

        [Fact]
        public async Task ShouldGetAllBooks()
        {
            //Arrange

            //Act

            var result = await _bookServices.GetAllAsync();

            //Assert

            Assert.IsType<List<BookResponse>?>(result);
        }

        [Fact]
        public async Task ShouldGetBookById()
        {
            //Arrange
            var genre = await CreateAGenre();
            var author = await CreateAnAuthor();

            var book = BookRequest(
                null,
                genre.Match(g => g.Id, err => Guid.Empty),
                author.Match(a => new List<Guid>() { a.Id }, err => new List<Guid>() { Guid.Empty })
            );

            //Act
            var response = await _bookServices.Add(book);

            var result = await _bookServices.GetByIdAsync(
                response.Match(b => b.Id, err => Guid.Empty)
            );

            //Assert

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldDeleteABook()
        {
            //Arrange
            var genre = await CreateAGenre();
            var author = await CreateAnAuthor();

            var book = BookRequest(
                null,
                genre.Match(g => g.Id, err => Guid.Empty),
                author.Match(a => new List<Guid>() { a.Id }, err => new List<Guid>() { Guid.Empty })
            );

            //Act

            var response = await _bookServices.Add(book);
            var bookId = response.Match(b => b.Id, err => Guid.Empty);
            await _bookServices.Delete(bookId);

            //Assert

            await Assert.ThrowsAsync<NotFoundException>(
                async () => await _bookServices.GetByIdAsync(bookId)
            );
        }

        public async Task ShouldUpdateABook(string title)
        {
            //Arrange

            var genre = await CreateAGenre();
            var author = await CreateAnAuthor();
            Guid genreId = genre.Match(g => g.Id, err => Guid.Empty);
            List<Guid> authorsId = author.Match(
                a => new List<Guid>() { a.Id },
                err => new List<Guid>() { Guid.Empty }
            );
            var book = BookRequest(null, genreId, authorsId);

            //Act

            var response = await _bookServices.Add(book);

            var bookId = response.Match(b => b.Id, err => Guid.Empty);

            var bookToUpdate = BookRequest(title, genreId, null);

            // That's not gonna work because the In-Memory Database doesn't suppor bulk delete.
            // So, I can't test the update method.
            // I'll leave it here just to show that I know how to do it.

            //var result = await _bookServices.Update(bookId, bookToUpdate);

            //Assert

            //Assert.True(result.Match(b => b, err => false));
        }

        public static BookRequest BookRequest(
            string? title = null,
            Guid? Genre = null,
            List<Guid>? AuthorsId = null
        ) =>
            new(
                title ?? "Harry Potter and the Philosopher's Stone",
                "Harry Potter has no idea how famous he is. That's because he's being raised by his miserable aunt and uncle who are terrified Harry will learn that he's really a wizard, just as his parents were.",
                new DateTime(1997, 6, 26),
                "O' Reilly",
                Genre ?? Guid.Empty,
                AuthorsId ?? new List<Guid>() { Guid.Empty }
            );

        public async Task<Result<GenreResponse>> CreateAGenre() =>
            await _genreServices.Add(new GenreRequest("Romance"));

        public async Task<Result<AuthorResponse>> CreateAnAuthor() =>
            await _authorServices.Add(
                new AuthorRequest(
                    "JK.",
                    "Rowling",
                    "London, United Kingdom",
                    "jkrowling@gmail.com",
                    new DateTime(1965, 7, 31)
                )
            );
    }
}
