using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            // Arrange
            var formatter = new HtmlFormatter();

            // Act
            var result = formatter.FormatAsBold("abc");

            //// Assert (specific)
            //Assert.That(result, Is.EqualTo("<strong>abc</strong>"));

            //// Assert (general)
            //Assert.That(result, Does.StartWith("<strong>"));

            // Assert (just right)
            Assert.That(result, Does.StartWith("<strong>").IgnoreCase);
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("abc"));
        }
    }
}