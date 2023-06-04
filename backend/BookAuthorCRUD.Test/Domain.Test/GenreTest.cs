using BookAuthorCRUD.Domain.Entities;

namespace BookAuthorCRUD.Test.Domain.Test
{
    public class GenreTest
    {

        [Fact]

        public void ShouldCreateBookUsingEmptyConstructor()
        {
            // Arrange
            var genre = new Genre();

            // Act

            // Assert
            Assert.IsType<Genre>(genre);
        }

        [Fact]
        public void ShouldCreateANewGenre()
        {
            // Arrange

            var genre = new { Id = Guid.NewGuid(), Name = "Fantasy" };

            // Act

            var result = Genre.Create(genre.Id, genre.Name);

            // Assert

            Assert.IsType<Genre>(result);
            Assert.Equal(genre.Id, result.Id);
        }
        [Theory]
        [InlineData("Terror")]
        [InlineData("Drama")]
        [InlineData("Fantasy")]
        public void ShouldUpdateGenre(string name)
        {
            // Arrange

            var genre = Genre.Create(Guid.NewGuid(), "Romance");

            // Act

            genre.Update(name);

            // Assert
            Assert.True(genre.Name == name);
        }
    }
}
