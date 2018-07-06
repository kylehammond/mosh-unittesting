using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class OrderServiceTests
    {
        [Test]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {
            // arrange
            var storage = new Mock<IStorage>();
            var service = new OrderService(storage.Object);
            var order = new Order();

            // act
            service.PlaceOrder(order);

            // assert
            storage.Verify(s => s.Store(order));
        }
    }
}
