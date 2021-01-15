using ComicStore.Shared.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ComicStore.Domain.POCO.Tests
{
    public class OrderItemBuilder :
        TestBuilder<OrderItemBuilder, OrderItem>
    {
        public OrderItemBuilder WithQuantity(int quantity)
        {
            Subject.Quantity = quantity;
            return this;
        }
    }

    [TestClass()]
    public class OrderItemTests
    {
        [TestMethod]
        [Description("Should be throw an error")]
        [ExpectedException(typeof(LessThanZeroException))]
        public void NegativeQuantityDownThrowsLessThanZeroException()
        {
            OrderItemBuilder.Create()
                            .WithQuantity(-1)
                            .Build();
        }
    }
}