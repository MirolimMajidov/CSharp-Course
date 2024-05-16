using CalculatorApp;
using FluentAssertions;
using Moq;
using Xunit;

namespace UnitTesting.xUnit
{
    public class CalculatorTests
    {
        [Fact]
        public void CalculatorAdd_FirstValue4AndSecondValue11_ThatShouldBeEqultTo15()
        {
            // Arrange/Given
            var calculator = new Calculator();

            // Act/When
            var result = calculator.Add(4, 11);

            // Assert/Then
            result.Should().Be(15);
        }

        [Fact]
        public void CalculatorAdd_FirstValue5AndSecondValue6_ThatShouldNotBeEqultTo15()
        {
            // Arrange/Given
            var calculator = new Calculator();

            // Act/When
            var result = calculator.Add(5, 6);

            // Assert/Then
            result.Should().NotBe(15);
        }

        [Theory]
        [InlineData(5, 3, 8)]
        [InlineData(-1, -1, -2)]
        [InlineData(0, 0, 0)]
        [InlineData(100, 200, 300)]
        public void Add_AddsTwoNumbers_ReturnsSum(int a, int b, int expected)
        {
            // Arrange/Given
            var calculator = new Calculator();

            // Act/When
            int result = calculator.Add(a, b);

            // Assert/Then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(5, 3, 2)]
        [InlineData(-1, -1, 0)]
        [InlineData(0, 0, 0)]
        [InlineData(100, 50, 50)]
        public void Subtract_SubtractsTwoNumbers_ReturnsDifference(int a, int b, int expected)
        {
            // Arrange/Given
            var calculator = new Calculator();

            // Act/When
            int result = calculator.Subtract(a, b);

            // Assert/Then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(5, 3, 15)]
        [InlineData(-1, -1, 1)]
        [InlineData(0, 0, 0)]
        [InlineData(10, 20, 200)]
        public void Multiply_MultipliesTwoNumbers_ReturnsProduct(int a, int b, int expected)
        {
            // Arrange/Given
            var calculator = new Calculator();

            // Act/When
            int result = calculator.Multiply(a, b);

            // Assert/Then
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(10, 2, 5.0)]
        [InlineData(9, 3, 3.0)]
        [InlineData(7, 1, 7.0)]
        [InlineData(100, 25, 4.0)]
        public void Divide_DividesTwoNumbers_ReturnsQuotient(int a, int b, double expected)
        {
            // Arrange/Given
            var calculator = new Calculator();

            // Act/When
            double result = calculator.Divide(a, b);

            // Assert/Then
            result.Should().BeApproximately(expected, 0.001);
        }

        [Theory]
        [InlineData(10, 0)]
        [InlineData(-5, 0)]
        [InlineData(0, 0)]
        public void Divide_DivideByZero_ThrowsArgumentException(int a, int b)
        {
            // Arrange/Given
            var calculator = new Calculator();

            // Act/When
            Action act = () => calculator.Divide(a, b);

            // Assert/Then
            act.Should().Throw<ArgumentException>().WithMessage("Cannot divide by zero.");
        }
    }
}