using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class MathTests
    {
        [SetUp]
        public void SetUp()
        {
            // Arrange
            _math = new Math();
        }

        private Math _math;

        [Test]
        [TestCase(1, 2, 3)]
        //[Ignore("Because I wanted to")]
        public void Add_WhenCalled_ReturnTheSumOfArguments(int a, int b, int expectedResult)
        {
            // Act
            var result = _math.Add(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        // would want to implement for neg, 0, and pos
        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            // Act
            var result = _math.GetOddNumbers(5);

            // Assert
            Assert.That(result, Is.EquivalentTo(new[] {1, 3, 5}));


            //Assert.That(result, Is.Ordered);
            //Assert.That(result, Is.Unique);

            //Assert.That(result, Is.Not.Empty);

            //Assert.That(result.Count(), Is.EqualTo(3));

            //Assert.That(result, Does.Contain(1));
            //Assert.That(result, Does.Contain(3));
            //Assert.That(result, Does.Contain(5));
        }

        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnsGreaterArgumentUnlessSame(int a, int b, int expectedResult)
        {
            // Act
            var result = _math.Max(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}