namespace RefactoringDemo
{
    public abstract class Price
    {
        public abstract double GetAmount(int daysRented);

        public abstract int GetFrequentRenterPoints(int daysRented);
    }
}
