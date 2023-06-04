using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Author;
using BookAuthorCRUD.Domain.Exception;
using LanguageExt.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Test.Application.Test.Services
{
    public class AuthorServicesTest
    {
        private readonly IAuthorService _authorService;
        private readonly IServiceProvider _provider = Startup.ServiceProvider();

        public AuthorServicesTest()
        {
            _authorService = _provider.GetRequiredService<IAuthorService>();
        }

        [Fact]
        public async Task ShouldCreateANewAuthor()
        {
            // Arrange
            var author = new AuthorRequest(
                "JK.",
                "Rowling",
                "London, United Kingdom",
                "jkrowling@gmail.com",
                new DateTime(1965, 7, 31)
            );

            // Act

            var result = await _authorService.Add(author);

            // Assert

            Assert.IsType<Result<AuthorResponse>>(result);
        }

        [Fact]
        public async Task ShouldGetAllAuthors()
        {
            //Arrange

            //Act

            var result = await _authorService.GetAllAsync();

            //Assert

            Assert.IsType<List<AuthorResponse>?>(result);
        }

        [Fact]
        public async Task ShouldGetAuthorById()
        {
            //Arrange

            var author = new AuthorRequest(
                "JK.",
                "Rowling",
                "London, United Kingdom",
                "jkrowling@gmail.com",
                new DateTime(1965, 7, 31)
            );

            var result = await _authorService.Add(author);
            var authorId = result.Match(Succ: author => author.Id, Fail: ex => Guid.Empty);

            //Act

            var authorById = await _authorService.GetByIdAsync(authorId);

            //Assert

            Assert.IsType<AuthorResponse>(authorById);
            Assert.True(authorById.Id == authorId);
        }

        [Theory]
        [InlineData("J.K")]
        [InlineData("Joanne")]
        public async Task ShouldUpdateAuthor(string FirstName)
        {
            //Arrange
            var author = new AuthorRequest(
                "JK",
                "Rowling",
                "London, United Kingdom",
                "jk@gmail.com",
                new DateTime(1965, 7, 31)
            );

            var result = await _authorService.Add(author);

            var authorId = result.Match(Succ: author => author.Id, Fail: ex => Guid.Empty);

            var authorToUpdate = new AuthorRequest(
                FirstName,
                "Rowling",
                "London, United Kingdom",
                "jk@gmail.com",
                new DateTime(1965, 7, 31)
            );

            //Act

            var resultUpdate = await _authorService.Update(authorId, authorToUpdate);

            //Assert

            Assert.True(resultUpdate.Match(Succ: author => true, Fail: ex => false));
        }

        [Fact]
        public async Task ShouldDeleteAnAuthor()
        {
            //Arrange

            var author = new AuthorRequest(
                "JK",
                "Rowling",
                "London, United Kingdom",
                "jk@gmail.com",
                new DateTime(1965, 7, 31)
            );

            var result = await _authorService.Add(author);

            var authorId = result.Match(Succ: author => author.Id, Fail: ex => Guid.Empty);

            //Act

            await _authorService.Delete(authorId);

            //Assert

            await Assert.ThrowsAsync<NotFoundException>(async()=>await _authorService.GetByIdAsync(authorId));
        }

        [Fact]

        public async Task Should_Throw_An_NotFoundException()
        {
            //Arrange

            var authorId = Guid.NewGuid();

            //Act

            var result = await Record.ExceptionAsync(() => _authorService.GetByIdAsync(authorId));

            //Assert

            Assert.IsType<NotFoundException>(result);
        }
    }
}
