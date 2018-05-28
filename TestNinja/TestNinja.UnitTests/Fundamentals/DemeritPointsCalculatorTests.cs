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
    public class DemeritPointsCalculatorTests
    {
        [SetUp]
        public void SetUp()
        {
            // Arrange
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }

        private DemeritPointsCalculator _demeritPointsCalculator;

        // Assumptions:
        // Speed can't be lower than 0
        // Speed can't exceed 300
        // Speed limit is 65
        // If speed <= speed limit, no points
        // For every 5 over speed limit, 1 demerit point

        // Test cases:
        // speed < 0, ArgumentOutOfRangeException
        // speed > 300, ArgumentOutOfRangeException

        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedOutsidePossibleRange_ArgumentOutOfRangeException(int speed)
        {
            // Act, Assert
            Assert.That(() => _demeritPointsCalculator.CalculateDemeritPoints(speed), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        public void CalculateDemeritPoints_SpeedBelowOrAtLimit_ZeroDemeritPoints(int speed, int expectedResult)
        {
            // Act
            var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(69,0)]
        [TestCase(71, 1)]
        [TestCase(74, 1)]
        [TestCase(76, 2)]
        [TestCase(79, 2)]
        [TestCase(81, 3)]
        public void CalculateDemeritPoints_SpeedAtUpperOrLowerBoundBeforeDemeritPoint_ReturnsAppropriateDemeritPoints(int speed, int expectedResult)
        {
            // Act
            var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        [TestCase(80, 3)]
        public void CalculateDemeritPoints_SpeedOverLimitAndDivisableByFive_ReturnsAppropriateDemeritPoints(int speed, int expectedResult)
        {
            // Act
            var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
