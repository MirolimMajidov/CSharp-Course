using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTesting.MSTest
{
    [TestClass]
    public class CalculatorTests : BaseTestInit
    {
        private Calculator calculator;

        public CalculatorTests()
        {
            // Arrange
            calculator = new Calculator();
        }

        [TestMethod]
        public void CalculatorAdd_FirstValue4AndSecondValue11_ThatShouldBeEqultTo15()
        {
            // Arrange/Given
            var calculator = new Calculator();

            // Act/When
            var result = calculator.Add(4, 11);

            // Assert/Then
            Assert.AreEqual(15, result);
            result.Should().Be(15);
        }

        [TestMethod]
        public void CalculatorAdd_FirstValue5AndSecondValue6_ThatShouldBotBeEqultTo15()
        {
            // Act
            var result = calculator.Add(5, 6);

            // Assert
            Assert.AreNotEqual(15, result);
            result.Should().NotBe(15);
        }

        [DataTestMethod]
        [DataRow(5, 3, 8)]
        [DataRow(-1, -1, -2)]
        [DataRow(0, 0, 0)]
        [DataRow(100, 200, 300)]
        public void Add_AddsTwoNumbers_ReturnsSum(int a, int b, int expected)
        {
            // Arrange/Given
            calculator = new Calculator();

            // Act/When
            int result = calculator.Add(a, b);

            // Assert/Then
            Assert.AreEqual(expected, result);
            result.Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(5, 3, 2)]
        [DataRow(-1, -1, 0)]
        [DataRow(0, 0, 0)]
        [DataRow(100, 50, 50)]
        public void Subtract_SubtractsTwoNumbers_ReturnsDifference(int a, int b, int expected)
        {
            // Act
            int result = calculator.Subtract(a, b);

            // Assert
            Assert.AreEqual(expected, result);
            result.Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(5, 3, 15)]
        [DataRow(-1, -1, 1)]
        [DataRow(0, 0, 0)]
        [DataRow(10, 20, 200)]
        public void Multiply_MultipliesTwoNumbers_ReturnsProduct(int a, int b, int expected)
        {
            // Act
            int result = calculator.Multiply(a, b);

            // Assert
            Assert.AreEqual(expected, result);
            result.Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(10, 2, 5.0)]
        [DataRow(9, 3, 3.0)]
        [DataRow(7, 1, 7.0)]
        [DataRow(100, 25, 4.0)]
        public void Divide_DividesTwoNumbers_ReturnsQuotient(int a, int b, double expected)
        {
            // Act
            double result = calculator.Divide(a, b);

            // Assert
            Assert.AreEqual(expected, result, 0.001);
            result.Should().BeApproximately(expected, 0.001);
        }

        [DataTestMethod]
        [DataRow(10, 0)]
        [DataRow(-5, 0)]
        [DataRow(0, 0)]
        public void Divide_DivideByZero_ThrowsArgumentException(int a, int b)
        {
            // Act
            Action act = () => calculator.Divide(a, b);

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("Cannot divide by zero.");
        }
    }
}
