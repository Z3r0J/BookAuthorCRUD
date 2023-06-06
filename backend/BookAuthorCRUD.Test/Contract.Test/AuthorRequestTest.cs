using BookAuthorCRUD.Contract.DTOs.Author;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Test.Contract.Test
{
    public class AuthorRequestTest
    {
        private readonly IServiceProvider _serviceProvider = Startup.ServiceProvider();
        private readonly IValidator<AuthorRequest> _validator;

        public AuthorRequestTest()
        {
            _validator =
                (IValidator<AuthorRequest>)
                    _serviceProvider.GetService(typeof(IValidator<AuthorRequest>))!;
        }

        [Theory]
        [InlineData("")]
        public void ShouldHaveAnInvalidAuthorRequest(string name)
        {
            //Arrange
            var authorRequest = new AuthorRequest(name, "", "", "", DateTime.Now);

            //Act
            var result = _validator.Validate(authorRequest);

            //Assert
            Assert.False(result.IsValid);
        }

        [Theory]
        [InlineData("Natalie")]
        [InlineData("Jean Carlos")]
        public void ShouldHaveAValidAuthorRequest(string name)
        {
            // Arrange
            var authorRequest = new AuthorRequest(name, "Lindsey", "London, United Kingdom", $"{name}@gmail.com", new DateTime(2021, 8, 10));

            // Act

            var result = _validator.Validate(authorRequest);

            // Assert

            Assert.True(result.IsValid);
        }
    }
}
