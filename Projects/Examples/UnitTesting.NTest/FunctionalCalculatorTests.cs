

using NUnit.Framework;

namespace UnitTesting.NTest
{
    public class FunctionalCalculatorTests : BaseTestInit
    {
        [Test]
        [TestCase(1, 2, 2)]
        [TestCase(5, 2, 10)]
        [TestCase(5, 5, 25)]
        public void CalculatorMultiply_ValuesArePassingForMultiply_ThatShouldBeEqultToMultiply(int firstValue, int secondValue, int expectedValue)
        {
            var calculator = new Calculator();
            var result = calculator.Multiply(firstValue, secondValue);
            Assert.AreEqual(expectedValue, result);
        }
    }
}