

using NUnit.Framework;

namespace UnitTesting.NTest
{
    public class CalculatorTests: BaseTestInit
    {
        [Test]
        public void CalculatorAdd_FirstValue4AndSecondValue11_ThatShouldBeEqultTo15()
        {
            var calculator = new Calculator();
            var result = calculator.Add(4, 11);
            Assert.AreEqual(15, result);
        }

        [Test]
        public void CalculatorAdd_FirstValue5AndSecondValue6_ThatShouldBotBeEqultTo15()
        {
            var calculator = new Calculator();
            var result = calculator.Add(5, 6);
            Assert.AreNotEqual(15, result);
        }
    }
}