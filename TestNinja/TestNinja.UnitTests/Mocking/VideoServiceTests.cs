﻿using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IFileReader> _fileReader;

        [SetUp]
        public void Setup()
        {
            _fileReader = new Mock<IFileReader>();
            _videoService = new VideoService(_fileReader.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            // arrange
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");
            
            // act
            var result = _videoService.ReadVideoTitle();

            // assert
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
