namespace RefactoringDemo
{
    public class Rental
    {
        public Movie Movie { get; }

        public int DaysRented { get; }

        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        public double GetAmount()
        {
            double result = 0;

            // Determine amounts for each rental
            switch (this.Movie.PricingType)
            {
                case PricingType.Regular:
                    result += 2;
                    if (this.DaysRented > 2)
                    {
                        result += (this.DaysRented - 2) * 1.5;
                    }

                    break;
                case PricingType.NewRelease:
                    result += this.DaysRented * 3;
                    break;
                case PricingType.Children:
                    result += 1.5;
                    if (this.DaysRented > 3)
                    {
                        result = (this.DaysRented - 3) * 1.5;
                    }

                    break;
            }

            return result;
        }

        public int GetFrequentRenterPoints()
        {
            // Add frequent renter points
            int frequentRenterPoints = 1;

            // Add bonus for a two-day new-release rental
            if ((this.Movie.PricingType == PricingType.NewRelease) && (this.DaysRented > 1))
            {
                frequentRenterPoints++;
            }

            return frequentRenterPoints;
        }
    }
}