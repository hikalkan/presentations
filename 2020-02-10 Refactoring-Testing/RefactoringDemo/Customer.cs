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

            foreach (var rental in Rentals)
            {
                // Show figures for this rental
                result += $"- {rental.Movie.Title} ({rental.GetAmount():0.00}){Environment.NewLine}";
            }

            // Add footer lines
            result += $"Total amount: {GetTotalAmount():0.00}{Environment.NewLine}";
            result += "You earned " + GetTotalFrequentRenterPoints() + " frequent renter points.";

            return result;
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
            result += "You earned " + GetTotalFrequentRenterPoints() + " <b>frequent renter points</b>.</p>";

            return result;
        }

        public double GetTotalAmount()
        {
            return Rentals.Sum(r => r.GetAmount());
        }

        public int GetTotalFrequentRenterPoints()
        {
            return Rentals.Sum(r => r.GetFrequentRenterPoints());
        }
    }
}