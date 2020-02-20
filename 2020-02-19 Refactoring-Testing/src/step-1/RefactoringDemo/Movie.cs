namespace RefactoringDemo
{
    public class Movie
    {
        public string Title { get; }

        public PricingType PricingType { get; set; }

        public Movie(string title, PricingType pricingType)
        {
            Title = title;
            PricingType = pricingType;
        }
    }
}