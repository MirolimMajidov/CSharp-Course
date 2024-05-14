using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting.MSTest
{
    [TestClass]
    public class CalculatorTests: BaseTestInit
    {
        [TestMethod]
        public void CalculatorAdd_FirstValue4AndSecondValue11_ThatShouldBeEqultTo15()
        {
            var calculator = new Calculator();
            var result = calculator.Add(4, 11);
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void CalculatorAdd_FirstValue5AndSecondValue6_ThatShouldBotBeEqultTo15()
        {
            var calculator = new Calculator();
            var result = calculator.Add(5, 6);
            Assert.AreNotEqual(15, result);
        }
    }
}