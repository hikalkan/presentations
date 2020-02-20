namespace RefactoringDemo
{
    public class ChildrenPrice : Price
    {
        public override double GetAmount(int daysRented)
        {
            var result = 1.5;

            if (daysRented > 3)
            {
                result = (daysRented - 3) * 1.5;
            }

            return result;
        }

        public override int GetFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }
}