using Shouldly;
using Xunit;

namespace RefactoringDemo.Tests
{
    public class Rental_Tests
    {
        [Fact]
        public void GetAmount()
        {
            // Arrange

            var rental = new Rental(new Movie("Ice Age", PricingType.NewRelease), 2);

            // Act

            var amount = rental.GetAmount();

            // Assert

            Assert.Equal(6, amount);
        }
    }
}
