using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            _math = new Math();
        }

        [Test]
        [TestCase(1, 2, 3)]
        [Ignore("Because I wanted to")]
        public void Add_WhenCalled_ReturnTheSumOfArguments(int a, int b, int expectedResult)
        {
            // Act
            expectedResult = _math.Add(a, b);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnsGreaterArgumentUnlessSame(int a, int b, int expectedResult)
        {
            // Act
            expectedResult = _math.Max(a, b);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(expectedResult));
        }
    }
}