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