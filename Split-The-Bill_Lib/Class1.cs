namespace Split_The_Bill_Lib;

public class SplitCalculator
{
    public decimal CalculateSplitAmount (decimal totalAmount,int numberOfPeople)
    {
         if (numberOfPeople <= 0)
        {
            throw new ArgumentException("Number of people must be greater than zero.", nameof(numberOfPeople));
        }

        return Math.Round(totalAmount / numberOfPeople, 2);
    }

}

class Program
{
    static void Main()
    {
        SplitCalculator splitter = new SplitCalculator();
        decimal totalAmount = 100.00m;
        int numberOfPeople = 5;
        
        try
        {
            decimal splitAmount = splitter.CalculateSplitAmount(totalAmount, numberOfPeople);
            Console.WriteLine($"The split amount per person is: ${splitAmount}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

