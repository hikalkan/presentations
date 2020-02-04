using System;
using System.Collections.Generic;

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

            var totalAmount = 0.0;
            var frequentRenterPoints = 0;

            foreach (var rental in Rentals)
            {
                double thisAmount = 0;

                // Determine amounts for each rental
                switch (rental.Movie.PricingType)
                {
                    case PricingType.Regular:
                        thisAmount += 2;
                        if (rental.DaysRented > 2)
                        {
                            thisAmount += (rental.DaysRented - 2) * 1.5;
                        }

                        break;
                    case PricingType.NewRelease:
                        thisAmount += rental.DaysRented * 3;
                        break;
                    case PricingType.Children:
                        thisAmount += 1.5;
                        if (rental.DaysRented > 3)
                        {
                            thisAmount = (rental.DaysRented - 3) * 1.5;
                        }

                        break;
                }

                // Add frequent renter points
                frequentRenterPoints++;

                // Add bonus for a two-day new-release rental
                if ((rental.Movie.PricingType == PricingType.NewRelease) && (rental.DaysRented > 1))
                {
                    frequentRenterPoints++;
                }

                // Show figures for this rental
                result += $"- {rental.Movie.Title} ({thisAmount:0.00}){Environment.NewLine}";
                totalAmount += thisAmount;
            }

            // Add footer lines
            result += $"Total amount: {totalAmount:0.00}{Environment.NewLine}";
            result += "You earned " + frequentRenterPoints + " frequent renter points.";

            return result;
        }
    }
}