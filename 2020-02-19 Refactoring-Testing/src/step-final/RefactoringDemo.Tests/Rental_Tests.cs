using Xunit;

namespace RefactoringDemo.Tests
{
    public class Rental_Tests
    {
        [Fact]
        public void GetAmount()
        {
            //Arrange
            var movie = new Movie("Back to the future!", new NewReleasePrice());
            var rental = new Rental(movie, 3);

            //Act
            var amount = rental.GetAmount();

            //Assert
            Assert.Equal(9, amount);
        }

        [Fact]
        public void GetFrequentRenterPoints()
        {
            //Arrange
            var movie = new Movie("Back to the future!", new NewReleasePrice());
            var rental = new Rental(movie, 2);

            //Act
            var frequentRenterPoints = rental.GetFrequentRenterPoints();

            //Assert
            Assert.Equal(2, frequentRenterPoints);
        }
    }
}
