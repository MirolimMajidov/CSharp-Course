using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting.MSTest
{
    [TestClass]
    public class FunctionalCalculatorTests : BaseTestInit
    {
        [TestMethod]
        [DataRow(1, 2, 2)]
        [DataRow(5, 2, 10)]
        [DataRow(5, 5, 25)]
        public void CalculatorMultiply_ValuesArePassingForMultiply_ThatShouldBeEqultToMultiply(int firstValue, int secondValue, int expectedValue)
        {
            var calculator = new Calculator();
            var result = calculator.Multiply(firstValue, secondValue);
            Assert.AreEqual(expectedValue, result);
        }
    }
}