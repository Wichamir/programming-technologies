namespace Tests;
using Task0;
using static System.Runtime.InteropServices.JavaScript.JSType;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        FactorialCalculator calculator = new FactorialCalculator();

        Assert.AreEqual(24, calculator.Calculate(4));
    }

    [TestMethod]
    public void TestMethod2()
    {
        FactorialCalculator calculator = new FactorialCalculator();

        Assert.AreNotEqual(3, calculator.Calculate(3));
    }
}