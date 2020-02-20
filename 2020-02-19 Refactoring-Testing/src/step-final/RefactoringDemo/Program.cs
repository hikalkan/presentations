using System;

namespace RefactoringDemo
{
    class Program
    {
        static void Main(string[] args)
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

            Console.WriteLine(customerJohn.GetHtmlInvoice());
        }
    }
}
