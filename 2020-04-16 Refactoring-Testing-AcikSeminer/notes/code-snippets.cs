        [Fact]
        public void Should_Create_Invoice_With_A_Few_Rentals()
        {
            // Arrange

            // Create some movies
            var iceAge = new Movie("Ice Age", PricingType.Children);
            var pulpFiction = new Movie("Pulp Fiction", PricingType.Regular);
            var joker = new Movie("Joker", PricingType.NewRelease);
            // Create some customers
            var customerJohn = new Customer("John Nash");
            // Add rentals to customers
            customerJohn.Rentals.Add(new Rental(iceAge, 2));
            customerJohn.Rentals.Add(new Rental(pulpFiction, 2));
            customerJohn.Rentals.Add(new Rental(joker, 3));

            // Act

            var invoice = customerJohn.GetInvoice();

            // Assert

            invoice.ShouldBe(
                @"Rental record for John Nash:
- Ice Age (1.50)
- Pulp Fiction (2.00)
- Joker (9.00)
Total amount: 12.50
You earned 4 frequent renter points.");
        }

        [Fact]
        public void Should_Create_Invoice_With_No_Rental()
        {
            // Arrange

            var customerJohn = new Customer("John Nash");

            // Act

            var invoice = customerJohn.GetInvoice();

            // Assert

            invoice.ShouldBe(
                @"Rental record for John Nash:
Total amount: 0.00
You earned 0 frequent renter points.");
        }
        
        
/////////////////////////////////////////////////////////////////////////////////////////

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

/////////////////////////////////////////////////////////////////////////////////////////


        private int GetFrequentRenterPoints(Rental rental)
        {
            // Add frequent renter points
            var frequentRenterPoints = 1;

            // Add bonus for a two-day new-release rental
            if ((rental.Movie.PricingType == PricingType.NewRelease) && (rental.DaysRented > 1))
            {
                frequentRenterPoints++;
            }

            return frequentRenterPoints;
        }
        
        //Değiştir:
        
        frequentRenterPoints += GetFrequentRenterPoints(rental);


/////////////////////////////////////////////////////////////////////////////////////////


        [Fact]
        public void Should_Create_Invoice_With_A_Few_Rentals_And_Produce_Html_Output()
        {
            // Arrange

            // Create some movies
            var iceAge = new Movie("Ice Age", PricingType.Children);
            var pulpFiction = new Movie("Pulp Fiction", PricingType.Regular);
            var joker = new Movie("Joker", PricingType.NewRelease);
            // Create some customers
            var customerJohn = new Customer("John Nash");
            // Add rentals to customers
            customerJohn.Rentals.Add(new Rental(iceAge, 2));
            customerJohn.Rentals.Add(new Rental(pulpFiction, 2));
            customerJohn.Rentals.Add(new Rental(joker, 3));

            // Act

            var invoice = customerJohn.GetHtmlInvoice();

            // Assert

            invoice.ShouldBe("<h1>Rental record for <i>John Nash</i>:</h1><ul><li> Ice Age (1.50)</li><li> Pulp Fiction (2.00)</li><li> Joker (9.00)</li></ul><p><b>Total amount</b>: 12.50<br />You earned 4 <b>frequent renter points</b>.</p>");
        }


        public string GetHtmlInvoice()
        {
            var result = $"<h1>Rental record for <i>{Name}</i>:</h1>";

            result += "<ul>";

            foreach (var rental in Rentals)
            {
                // Show figures for this rental
                result += $"<li> {rental.Movie.Title} ({rental.GetAmount():0.00})</li>";
            }

            result += "</ul>";

            // Add footer lines
            result += $"<p><b>Total amount</b>: {GetTotalAmount():0.00}<br />";
            result += "You earned " + GetTotalFrequentRentalPoints() + " <b>frequent renter points</b>.</p>";

            return result;
        }