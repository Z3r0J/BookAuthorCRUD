using BookAuthorCRUD.Contract.DTOs.Book;
using FluentValidation;

namespace BookAuthorCRUD.Test.Contract.Test
{
    public class BookRequestTest
    {
        private readonly IServiceProvider _serviceProvider = Startup.ServiceProvider();
        private readonly IValidator<BookRequest> _validator;

        public BookRequestTest()
        {
            _validator =
                (IValidator<BookRequest>)
                    _serviceProvider.GetService(typeof(IValidator<BookRequest>))!;
        }

        [Fact]
        public void ShouldHaveAnInvelidBookRequest()
        {
            //Arrange
            var book = new BookRequest(
                "",
                "It's a good book.",
                new DateTime(2001, 05, 14),
                "O'Reilly",
                Guid.NewGuid(),
                new() { Guid.Empty }
            );

            //Act
            var result = _validator.Validate(book);

            //Assert
            Assert.False(result.IsValid);
        }

        [Theory]
        [InlineData("Harry Potter")]
        [InlineData("The Great Gatsby")]
        public void ShouldHaveAValidBookRequest(string name)
        {
            //Arrange
            var book = new BookRequest(
                name,
                "It's a good book.",
                new DateTime(2001, 05, 14),
                "O'Reilly",
                Guid.NewGuid(),
                new() { Guid.Empty }
            );

            //Act
            var result = _validator.Validate(book);

            //Assert

            Assert.True(result.IsValid);
        }
    }
}
