using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class FizzBuzzTests
    {

        [Test]
        [TestCase(15, "FizzBuzz")] // number is divisible by 3 and 5, return fizzbuzz
        [TestCase(3, "Fizz")]// number is divisible by 3 and not 5, return fizz
        [TestCase(5, "Buzz")] // number is divisible by 5 and not 3, return buzz
        [TestCase(1, "1")]    // number is not divisible by 3 or 5, return number.tostring
        public void GetOutput_WhenCalled_ReturnFizzBuzzBasedOnInput(int number, string expectedResult)
        {
            // Arrange, Act
            var result = FizzBuzz.GetOutput(number);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }

}
