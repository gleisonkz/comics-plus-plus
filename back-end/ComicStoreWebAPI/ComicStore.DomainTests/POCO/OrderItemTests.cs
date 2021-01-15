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

        public OrderItemBuilder WithUnitValue(decimal value)
        {
            Subject.UnitValue = value;
            return this;
        }

        public OrderItemBuilder WithTotalValue(decimal value)
        {
            Subject.TotalValue = value;
            return this;
        }
    }

    [TestClass()]
    public class OrderItemTests
    {
        [TestMethod]
        [Description("Should be throw an LessThanZeroException")]
        [ExpectedException(typeof(LessThanZeroException))]
        public void NegativeQuantityDown()
        {
            OrderItemBuilder.Create()
                            .WithQuantity(-1)
                            .Build();
        }

        [TestMethod]
        [Description("Should be throw an LessThanZeroException")]
        [ExpectedException(typeof(LessThanZeroException))]
        public void NegativeUnityValue()
        {
            OrderItemBuilder.Create()
                            .WithUnitValue(-1)
                            .Build();
        }

        [TestMethod]
        [Description("Should be throw an LessThanZeroException")]
        [ExpectedException(typeof(LessThanZeroException))]
        public void NegativeTotalValue()
        {
            OrderItemBuilder.Create()
                            .WithTotalValue(-1)
                            .Build();
        }

        [TestMethod]
        [Description("TotalValue can not be less than UnitValue, should be throw an CustomException")]
        [ExpectedException(typeof(CustomException))]
        public void TotalValueLessThanUnitValue()
        {
            OrderItemBuilder.Create()
                            .WithUnitValue(50.55M)
                            .WithTotalValue(50.50M)
                            .Build();
        }
    }
}