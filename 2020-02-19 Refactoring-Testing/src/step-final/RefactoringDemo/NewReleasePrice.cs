namespace RefactoringDemo
{
    public class NewReleasePrice : Price
    {
        public override double GetAmount(int daysRented)
        {
            return daysRented * 3;
        }

        public override int GetFrequentRenterPoints(int daysRented)
        {
            return daysRented > 1
                ? 2
                : 1;
        }
    }
}