using Shouldly;
using Xunit;

namespace RefactoringDemo.Tests
{
    public class Customer_Tests
    {
        [Fact]
        public void GetTotalAmount_And_TotalFrequentRenterPoints()
        {
            // Create some movies

            var iceAge = new Movie("Ice Age", new ChildrenPrice());
            var pulpFiction = new Movie("Pulp Fiction", new RegularPrice());
            var joker = new Movie("Joker", new NewReleasePrice());

            // Create some customers

            var customerJohn = new Customer("John Nash");

            // Add rentals to customers

            customerJohn.Rentals.Add(new Rental(iceAge, 2));
            customerJohn.Rentals.Add(new Rental(pulpFiction, 2));
            customerJohn.Rentals.Add(new Rental(joker, 3));

            //Assert

            customerJohn.GetTotalAmount().ShouldBe(12.5);
            customerJohn.GetTotalFrequentRenterPoints().ShouldBe(4);
        }

        [Fact]
        public void Should_Create_Invoice_With_No_Rental()
        {
            var customerJohn = new Customer("John Nash");

            customerJohn.GetInvoice().ShouldBe(
                @"Rental record for John Nash:
Total amount: 0.00
You earned 0 frequent renter points.");
        }

        [Fact]
        public void Should_Create_Invoice_With_A_Few_Rentals()
        {
            // Create some movies

            var iceAge = new Movie("Ice Age", new ChildrenPrice());
            var pulpFiction = new Movie("Pulp Fiction", new RegularPrice());
            var joker = new Movie("Joker", new NewReleasePrice());

            // Create some customers

            var customerJohn = new Customer("John Nash");

            // Add rentals to customers

            customerJohn.Rentals.Add(new Rental(iceAge, 2));
            customerJohn.Rentals.Add(new Rental(pulpFiction, 2));
            customerJohn.Rentals.Add(new Rental(joker, 3));

            // Print the invoices

            customerJohn.GetInvoice().ShouldBe(
                @"Rental record for John Nash:
- Ice Age (1.50)
- Pulp Fiction (2.00)
- Joker (9.00)
Total amount: 12.50
You earned 4 frequent renter points.");

            customerJohn.GetHtmlInvoice().ShouldBe("<h1>Rental record for <i>John Nash</i>:</h1><ul><li> Ice Age (1.50)</li><li> Pulp Fiction (2.00)</li><li> Joker (9.00)</li></ul><p><b>Total amount</b>: 12.50<br />You earned 4 <b>frequent renter points</b>.</p>");
        }
    }
}
