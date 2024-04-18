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

public class TipCalculator
{
    public Dictionary<string, decimal> CalculateTipPerPerson(Dictionary<string, decimal> mealCosts, float tipPercentage)
    {
        if (mealCosts == null || mealCosts.Count == 0)
        {
            throw new ArgumentException("Meal costs dictionary cannot be null or empty.", nameof(mealCosts));
        }

        if (tipPercentage < 0 || tipPercentage > 100)
        {
            throw new ArgumentException("Tip percentage must be between 0 and 100.", nameof(tipPercentage));
        }

        Dictionary<string, decimal> tipAmounts = new Dictionary<string, decimal>();

        foreach (var kvp in mealCosts)
        {
            decimal tipAmount = kvp.Value * (decimal)(tipPercentage / 100);
            tipAmounts.Add(kvp.Key, tipAmount);
        }

        return tipAmounts;
    }
}
