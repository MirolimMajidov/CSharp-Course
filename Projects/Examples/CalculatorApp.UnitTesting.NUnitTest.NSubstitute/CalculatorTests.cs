using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;

namespace UnitTesting.NUnit
{
    [TestFixture]
    public class CalculatorTests
    {
        private ILogger _loggerMock;
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _loggerMock = Substitute.For<ILogger>();
            _calculator = new Calculator(_loggerMock);
        }

        [Test]
        public void CalculatorAdd_FirstValue4AndSecondValue11_ThatShouldBeEqultTo15()
        {
            // Act/When
            var result = _calculator.Add(4, 11);

            // Assert/Then
            result.Should().Be(15);
            _loggerMock.Received(1).Log("Adding 4 and 11");
        }

        [Test]
        public void CalculatorAdd_FirstValue5AndSecondValue6_ThatShouldNotBeEqultTo15()
        {
            // Act/When
            var result = _calculator.Add(5, 6);

            // Assert/Then
            result.Should().NotBe(15);
            _loggerMock.Received(1).Log("Adding 5 and 6");
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
            _loggerMock.Received(1).Log($"Adding {a} and {b}");
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
            _loggerMock.Received(1).Log($"Subtracting {b} from {a}");
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
            _loggerMock.Received(1).Log($"Multiplying {a} and {b}");
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
            _loggerMock.Received(1).Log($"Dividing {a} by {b}");
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
            _loggerMock.Received(1).Log("Attempted to divide by zero");
        }
    }
}
