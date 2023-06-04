using BookAuthorCRUD.Application.Interface;
using BookAuthorCRUD.Contract.DTOs.Genre;
using BookAuthorCRUD.Domain.Exception;
using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Test.Application.Test.Services
{
    public class GenreServices
    {
        private readonly IServiceProvider _serviceProvider = Startup.ServiceProvider();
        private readonly IGenreService _genreServices;

        public GenreServices()
        {
            _genreServices = (IGenreService)_serviceProvider.GetService(typeof(IGenreService))!;
        }

        [Fact]

        public async Task ShouldCreateAGenre()
        {
            //Arrange

            var genre = GenreRequest();

            //Act

            var response = await _genreServices.Add(genre);

            //Assert

            Assert.IsType<Result<GenreResponse>>(response);
        }

        [Fact]

        public async Task ShouldGetAllGenres()
        {
            //Arrange

            //Act

            var result = await _genreServices.GetAllAsync();

            //Assert

            Assert.IsType<List<GenreResponse>?>(result);
        }

        [Fact]

        public async Task ShouldGetGenreById()
        {
            //Arrange

            GenreRequest genre = GenreRequest();

            var response = await _genreServices.Add(genre);
            Guid genreId = response.Match(g => g.Id, err => Guid.Empty);

            //Act

            var result = await _genreServices.GetByIdAsync(genreId);

            //Assert

            Assert.IsType<GenreResponse>(result);
        }

        [Fact]
        public async Task ShouldDeleteAGenre()
        {
            //Arrange

            GenreRequest genre = GenreRequest();

            var response = await _genreServices.Add(genre);
            Guid genreId = response.Match(g => g.Id, err => Guid.Empty);

            //Act

            await _genreServices.Delete(genreId);

            //Assert

            await Assert.ThrowsAsync<NotFoundException>(async () => await _genreServices.GetByIdAsync(genreId));
        }

        [Theory]
        [InlineData("Fantasy")]
        [InlineData("Terror")]
        public async Task ShouldUpdateAGenre(string name)
        {
            //Arrange

            GenreRequest genre = GenreRequest();

            var response = await _genreServices.Add(genre);
            Guid genreId = response.Match(g => g.Id, err => Guid.Empty);

            //Act

            var result = await _genreServices.Update(genreId, GenreRequest(name));

            //Assert

            Assert.True(result.Match(g=>g,err=>false));
        }

        public static GenreRequest GenreRequest(string? name = null)
        {
            return new GenreRequest(name ?? "Romance");
        }
    }
}
