using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class StackTests
    {
        [SetUp]
        public void Setup()
        {
            // Arrange
            _stack = new Stack<object>();
        }

        private Stack<object> _stack;

        [Test]
        public void Push_WhenCalled_ObjectAddedToList()
        {
            // Arrange
            var originalCount = _stack.Count;

            // Act
            _stack.Push(4);

            // Assert
            Assert.That(_stack.Count == originalCount + 1);

            // I can't peek to find what I added and I can't check the list because it's private...
        }

        [Test]
        public void Push_WhenObjectNull_ThrowArgumentNullException()
        {
            // Act, Assert
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Pop_WhenCalled_ItemRemovedAndReturned()
        {
            // Arrange
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);
            var originalCount = _stack.Count;

            // Act
            var result = _stack.Pop();

            // Assert 
            Assert.That(result, Is.EqualTo(3));
            Assert.That(_stack.Count == originalCount - 1);
        }

        [Test]
        public void Pop_WhenListEmpty_ThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_WhenCalled_ItemReturned()
        {
            // Arrange
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);
            var originalCount = _stack.Count;

            // Act
            var result = _stack.Peek();

            // Assert 
            Assert.That(result, Is.EqualTo(3));
            Assert.That(_stack.Count == originalCount);
        }
        
        [Test]
        public void Peek_WhenListEmpty_ThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }
    }
}