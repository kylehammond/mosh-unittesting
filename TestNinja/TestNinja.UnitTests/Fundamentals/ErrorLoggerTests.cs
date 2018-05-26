using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    internal class ErrorLoggerTests
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            // Arrange
            var logger = new ErrorLogger();

            // Act, Assert
            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);
        }


        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            // Arrange
            var logger = new ErrorLogger();

            // Act
            var id = Guid.Empty;
            logger.ErrorLogged += (sender, args) => { id = args; };

            logger.Log("a");

            // Assert
            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }

        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            // Arrange
            var logger = new ErrorLogger();

            // Act
            logger.Log("a");

            // Assert
            Assert.That(logger.LastError, Is.EqualTo("a"));
        }
    }
}