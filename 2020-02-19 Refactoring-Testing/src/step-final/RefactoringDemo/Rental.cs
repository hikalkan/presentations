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
            return Movie.GetAmount(DaysRented);
        }

        public int GetFrequentRenterPoints()
        {
            return Movie.GetFrequentRenterPoints(DaysRented);
        }
    }
}