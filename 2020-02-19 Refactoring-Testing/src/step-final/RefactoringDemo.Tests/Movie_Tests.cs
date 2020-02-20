using Xunit;

namespace RefactoringDemo.Tests
{
    public class Movie_Tests
    {
        [Fact]
        public void GetAmount()
        {
            //Arrange
            var movie = new Movie("Back to the future!", new NewReleasePrice());

            //Act
            var amount = movie.GetAmount(3);

            //Assert
            Assert.Equal(9, amount);
        }
    }
}
