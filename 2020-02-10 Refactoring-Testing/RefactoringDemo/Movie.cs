namespace RefactoringDemo
{
    public class Movie
    {
        public string Title { get; }

        public Price Pricing { get; set; }

        public Movie(string title, Price pricing)
        {
            Title = title;
            Pricing = pricing;
        }

        public double GetAmount(int daysRented)
        {
            return Pricing.GetAmount(daysRented);
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            return Pricing.GetFrequentRenterPoints(daysRented);
        }
    }
}