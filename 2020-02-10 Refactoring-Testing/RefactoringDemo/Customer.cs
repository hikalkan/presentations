using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactoringDemo
{
    public class Customer
    {
        public string Name { get; }

        public List<Rental> Rentals { get; }

        public Customer(string name)
        {
            Name = name;
            Rentals = new List<Rental>();
        }

        public string GetInvoice()
        {
            var result = $"Rental record for {Name}:{Environment.NewLine}";

            var totalAmount = GetTotalAmount();
            var frequentRenterPoints = GetTotalFrequentRentalPoints();

            foreach (var rental in Rentals)
            {
                // Show figures for this rental
                result += $"- {rental.Movie.Title} ({rental.GetAmount():0.00}){Environment.NewLine}";
            }

            // Add footer lines
            result += $"Total amount: {totalAmount:0.00}{Environment.NewLine}";
            result += "You earned " + frequentRenterPoints + " frequent renter points.";

            return result;
        }

        private double GetTotalAmount()
        {
            return Rentals.Sum(r => r.GetAmount());
        }

        private int GetTotalFrequentRentalPoints()
        {
            return Rentals.Sum(r => r.GetFrequentRenterPoints());
        }
    }
}