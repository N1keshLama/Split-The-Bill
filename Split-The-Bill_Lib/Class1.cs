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



        TipCalculator calculator = new TipCalculator();

        try
        {
            decimal tipPerPerson = calculator.CalculateTipPerPersonFromUserInput();
            Console.WriteLine($"Tip per person: ${tipPerPerson}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
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
    public decimal CalculateTipPerPersonFromUserInput()
    {
        Console.WriteLine("Enter the total price of the bill:");
        decimal totalPrice = ReadDecimalInput();

        Console.WriteLine("Enter the number of patrons:");
        int numberOfPatrons = ReadIntegerInput();

        Console.WriteLine("Enter the tip percentage (e.g., 15 for 15%):");
        float tipPercentage = ReadFloatInput();

        // Validate inputs
        if (numberOfPatrons <= 0)
        {
            throw new ArgumentException("Number of patrons must be greater than zero.", nameof(numberOfPatrons));
        }

        if (tipPercentage < 0 || tipPercentage > 100)
        {
            throw new ArgumentException("Tip percentage must be between 0 and 100.", nameof(tipPercentage));
        }
        decimal totalTipAmount = totalPrice * (decimal)(tipPercentage / 100);
        decimal tipPerPerson = totalTipAmount / numberOfPatrons;

        return Math.Round(tipPerPerson, 2);
    }

    private decimal ReadDecimalInput()
    {
        decimal value;
        while (!decimal.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Invalid input. Please enter a valid decimal value:");
        }
        return value;
    }

    private int ReadIntegerInput()
    {
        int value;
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer value:");
        }
        return value;
    }

    private float ReadFloatInput()
    {
        float value;
        while (!float.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Invalid input. Please enter a valid float value:");
        }
        return value;
    }
}
