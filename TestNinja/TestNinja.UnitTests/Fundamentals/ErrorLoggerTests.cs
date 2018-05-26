using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    class ErrorLoggerTests
    {
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
