using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;

namespace UnitTesting.NUnit
{
    [TestFixture]
    public class CalculatorTests
    {
        private Mock<ILogger> _loggerMock;
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger>();
            _calculator = new Calculator(_loggerMock.Object);
        }

        [Test]
        public void CalculatorAdd_FirstValue4AndSecondValue11_ThatShouldBeEqultTo15()
        {
            Mock<ILogger> _loggerMock = new Mock<ILogger>();
            Calculator _calculator = new Calculator(_loggerMock.Object);

            // Act/When
            var result = _calculator.Add(4, 11);

            // Assert/Then
            result.Should().Be(15);
            _loggerMock.Verify(logger => logger.Log("Adding 4 and 11"), Times.AtLeast(2));
        }

        [Test]
        public void CalculatorAdd_FirstValue5AndSecondValue6_ThatShouldNotBeEqultTo15()
        {
            // Act/When
            var result = _calculator.Add(5, 6);

            // Assert/Then
            result.Should().NotBe(15);
            _loggerMock.Verify(logger => logger.Log("Adding 5 and 6"), Times.AtLeast(2));
        }

        [TestCase(5, 3, 8)]
        [TestCase(-1, -1, -2)]
        [TestCase(0, 0, 0)]
        [TestCase(100, 200, 300)]
        public void Add_AddsTwoNumbers_ReturnsSum(int a, int b, int expected)
        {
            // Act/When
            int result = _calculator.Add(a, b);

            // Assert/Then
            result.Should().Be(expected);
            _loggerMock.Verify(logger => logger.Log($"Adding {a} and {b}"), Times.AtLeast(2));
        }

        [TestCase(5, 3, 2)]
        [TestCase(-1, -1, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(100, 50, 50)]
        public void Subtract_SubtractsTwoNumbers_ReturnsDifference(int a, int b, int expected)
        {
            // Act/When
            int result = _calculator.Subtract(a, b);

            // Assert/Then
            result.Should().Be(expected);
            _loggerMock.Verify(logger => logger.Log($"Subtracting {b} from {a}"), Times.Once);
        }

        [TestCase(5, 3, 15)]
        [TestCase(-1, -1, 1)]
        [TestCase(0, 0, 0)]
        [TestCase(10, 20, 200)]
        public void Multiply_MultipliesTwoNumbers_ReturnsProduct(int a, int b, int expected)
        {
            // Act/When
            int result = _calculator.Multiply(a, b);

            // Assert/Then
            result.Should().Be(expected);
            _loggerMock.Verify(logger => logger.Log($"Multiplying {a} and {b}"), Times.Once);
        }

        [TestCase(10, 2, 5.0)]
        [TestCase(9, 3, 3.0)]
        [TestCase(7, 1, 7.0)]
        [TestCase(100, 25, 4.0)]
        public void Divide_DividesTwoNumbers_ReturnsQuotient(int a, int b, double expected)
        {
            // Act/When
            double result = _calculator.Divide(a, b);

            // Assert/Then
            result.Should().BeApproximately(expected, 0.001);
            _loggerMock.Verify(logger => logger.Log($"Dividing {a} by {b}"), Times.Once);
        }

        [TestCase(10, 0)]
        [TestCase(-5, 0)]
        [TestCase(0, 0)]
        public void Divide_DivideByZero_ThrowsArgumentException(int a, int b)
        {
            // Act/When
            Action act = () => _calculator.Divide(a, b);

            // Assert/Then
            act.Should().Throw<ArgumentException>().WithMessage("Cannot divide by zero.");
            _loggerMock.Verify(logger => logger.Log("Attempted to divide by zero"), Times.Once);
        }
    }
}
