using ComicStore.DomainTests.Patterns.Builder;
using ComicStore.Shared.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComicStore.Domain.POCO.Tests
{
    [TestClass()]
    public class OrderItemTests
    {
        [TestMethod]
        [Description("Should be throw an LessThanZeroException")]
        [ExpectedException(typeof(LessThanZeroException))]
        public void NegativeQuantityValue()
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