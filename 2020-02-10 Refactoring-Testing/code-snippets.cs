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