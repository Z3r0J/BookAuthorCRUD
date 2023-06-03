using BookAuthorCRUD.Contract.DTOs.Author;
using BookAuthorCRUD.Contract.Validations.Author;
using BookAuthorCRUD.Domain.Entities;
using FluentValidation;
using Moq;

namespace BookAuthorCRUD.Test.Domain.Test
{
    public class AuthorTest
    {
        private IValidator<AuthorRequest> _validator;

        public AuthorTest()
        {
            _validator = new AuthorRequestValidation();
        }

        [Fact]
        public void ShouldCreateAuthor()
        {
            // Arrange
            var author = new
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                address="Av. 123 Brooklyn Street",
                email="johndoe@gmail.com",
                birthDate = DateTime.Now.AddYears(-18),
            };

            // Act
            var result = Author.Create(
                author.Id,
                author.FirstName,
                author.LastName,
                author.address,
                author.email,
                author.birthDate
                );

            // Assert
            Assert.Equal( author.Id, result.Id);
            Assert.IsType<Author>(result);
        }

        [Fact]
        public void ShouldNotCreateAuthorRequestWithEmptyFirstName()
        {
            // Arrange
            var author = new AuthorRequest(
                "",
                "Doe",
                "Av. 123 Brooklyn Street",
                "johndoe@gmail.com",
                DateTime.Now.AddYears(-18)
                );

            // Act

            var result = _validator.Validate(author);

            var message = result.Errors.FirstOrDefault(x => x.PropertyName == "FirstName")!.ErrorMessage;


            // Assert

            Assert.Equal("First name is required", message);
        }

        [Theory]
        [InlineData("Jean")]
        [InlineData("John")]
        public void ShouldUpdateAuthorFirstName(string firstNameToUpdate)
        {
            //Arrange

            var author = Author.Create(
                Guid.NewGuid(),
                "John",
                "Doe",
                "Av. 123 Brooklyn Street",
                "",
                DateTime.Now.AddYears(-18)
                );
            //Act

            author.Update(firstName: firstNameToUpdate);

            //Assert

            Assert.True(author.FirstName == firstNameToUpdate);

        }

    }
}