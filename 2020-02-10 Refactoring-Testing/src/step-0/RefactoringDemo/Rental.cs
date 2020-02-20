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
    }
}