using Split_The_Bill_Lib;
namespace Split_The_Bill.TEST;

[TestClass]
public class SplitCalculatorTests
{
    [TestMethod]
    public void TestCalculateSplitAmount_ValidInput()
    {
        decimal totalAmount = 100.00m;
        int numberOfPeople = 5;
        decimal actualSplitAmount = new SplitCalculator().CalculateSplitAmount(totalAmount, numberOfPeople);
        Assert.AreEqual(20.00m, actualSplitAmount, "Split amount calculation is incorrect.");
    }

   [TestMethod]
    public void TestCalculateSplitAmount_Negative_Input()
    {
        SplitCalculator splitter = new SplitCalculator();
        decimal totalAmount = 100.00m;
        int numberOfPeople = -5; 
        Assert.ThrowsException<ArgumentException>(() => splitter.CalculateSplitAmount(totalAmount, numberOfPeople),
            "ArgumentException should be thrown for negative numberOfPeople.");
    }

    [TestMethod]
    public void TestCalculateSplitAmount_ZeroPeople()
    {
        var splitter = new SplitCalculator();
        var totalAmount = 100.00m;
        var numberOfPeople = 0;
        Assert.ThrowsException<ArgumentException>(() => splitter.CalculateSplitAmount(totalAmount, numberOfPeople));
    }
    
}

[TestClass]
public class TipCalculatorTests
{
    [TestMethod]
    public void TestCalculateTipPerPerson_ValidInput()
    {
        TipCalculator calculator = new TipCalculator();
        Dictionary<string, decimal> mealCosts = new Dictionary<string, decimal>
        {
            { "Raju", 23.25m },
            { "Raja", 26.50m },
            { "Ram", 25.25m }
        };
        float tipPercentage = 15.0f;
        Dictionary<string, decimal> tipAmounts = calculator.CalculateTipPerPerson(mealCosts, tipPercentage);
        Assert.AreEqual(3.49m, Math.Round(tipAmounts["Raju"], 2), "Incorrect tip amount for Raju.");
        Assert.AreEqual(3.98m, Math.Round(tipAmounts["Raja"], 2), "Incorrect tip amount for Raja.");
        Assert.AreEqual(3.79m, Math.Round(tipAmounts["Ram"], 2), "Incorrect tip amount for Ram.");
    }

    [TestMethod]
    public void TestCalculateTipPerPerson_NullMealCosts()
    {
        TipCalculator calculator = new TipCalculator();
        Dictionary<string, decimal> mealCosts = null;
        float tipPercentage = 25.0f;
        Assert.ThrowsException<ArgumentException>(() => calculator.CalculateTipPerPerson(mealCosts, tipPercentage),
            "Exception should be thrown for null mealCosts.");
    }

    [TestMethod]
    public void TestCalculateTipPerPerson_InvalidTipPercentage()
    {
        TipCalculator calculator = new TipCalculator();
        Dictionary<string, decimal> mealCosts = new Dictionary<string, decimal>
        {
            { "Raju", 20.00m }
        };
        float invalidTipPercentage = -24.0f;
        Assert.ThrowsException<ArgumentException>(() => calculator.CalculateTipPerPerson(mealCosts, invalidTipPercentage),
            "Exception should be thrown for invalid tipPercentage.");
    }
}
