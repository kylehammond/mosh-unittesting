using NUnit.Framework;
using TestNinja.Mocking;
using TestNinja.UnitTests.Fakes;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            // arrange
            var service = new VideoService();
            service.FileReader = new FakeFileReader();
            
            // act
            var result = service.ReadVideoTitle();

            // assert
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
