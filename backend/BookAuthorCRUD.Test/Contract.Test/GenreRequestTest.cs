using BookAuthorCRUD.Contract.DTOs.Genre;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Test.Contract.Test
{
    public class GenreRequestTest
    {
        private readonly IServiceProvider _serviceProvider = Startup.ServiceProvider();
        private readonly IValidator<GenreRequest> _validator;

        public GenreRequestTest()
        {
            _validator = (IValidator<GenreRequest>)_serviceProvider.GetService(typeof(IValidator<GenreRequest>))!;
        }

        [Fact]

        public void ShouldHaveAnInvalidGenreRequest()
        {
            // Arrange

            var genreRequest = new GenreRequest("");

            // Act

            var result = _validator.Validate(genreRequest);

            // Assert

            Assert.False(result.IsValid);
        }

        [Theory]
        [InlineData("Fantasy")]
        [InlineData("Love")]

        public void ShouldHaveAValidGenreRequest(string name)
        {
            //Arrange
            
            var genre = new GenreRequest(name);

            //Act

            var result = _validator.Validate(genre);

            //Assert

            Assert.True(result.IsValid);

        }
    }
}
