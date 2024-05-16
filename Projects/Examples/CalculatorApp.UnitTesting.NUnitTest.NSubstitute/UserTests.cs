using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.UnitTesting.NUnitTest.NSubstitute
{
    internal class UserTests
    {
        [Test]
        public void FullName_Should_Return_Correct_Value()
        {
            // Arrange
            var user = new User { FirstName = "John", LastName = "Doe" };
            var expectedFullName = "John Doe";

            // Act
            var fullName = user.FullName;

            // Assert
            Assert.AreEqual(expectedFullName, fullName);
        }

        [Test]
        public void FullName_Should_Return_Correct_Value_Moq()
        {
            // Arrange
            Mock<User> userMock = new Mock<User>();
            userMock.SetupGet(p => p.FirstName).Returns("John");
            userMock.SetupGet(p => p.LastName).Returns("Doe");
            var user = userMock.Object;
            var expectedFullName = "John Doe";

            // Act
            var fullName = user.FullName;

            // Assert
            Assert.AreEqual(expectedFullName, fullName);
        }

        [Test]
        public void FullName_Should_Return_Correct_Value_NSubstitute()
        {
            // Arrange
            var user = Substitute.ForPartsOf<User>();
            user.FirstName.Returns("John");
            user.LastName.Returns("Doe");
            var expectedFullName = "John Doe";

            // Act
            var fullName = user.FullName;

            // Assert
            Assert.AreEqual(expectedFullName, fullName);
        }
    }
}
