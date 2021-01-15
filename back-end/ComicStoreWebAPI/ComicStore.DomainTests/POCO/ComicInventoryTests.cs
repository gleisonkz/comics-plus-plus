using ComicStore.Shared.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComicStore.Domain.POCO.Tests
{
    public abstract class TestBuilder<TBuilder, TSubject>
        where TBuilder : new()
        where TSubject : new()
    {
        protected readonly TSubject Subject = new TSubject();
        public static TBuilder Create()
        {
            return new TBuilder();
        }

        public TSubject Build()
        {
            return Subject;
        }
    }

    public class ComicInventoryBuilder
        : TestBuilder<ComicInventoryBuilder, ComicInventory>
    {
        public ComicInventoryBuilder WithQuantity(int quantity)
        {
            Subject.Quantity = quantity;
            return this;
        }
    }



    [TestClass()]
    public class ComicInventoryTests
    {
        [TestMethod]
        [Description("Should be reduced one unit of a positive value")]
        public void QuantityDownWithPositiveValueTest()
        {
            var comic = ComicInventoryBuilder.Create()
                                             .WithQuantity(1)
                                             .Build();

            comic.QuantityDown(1);
            Assert.AreEqual(0, comic.Quantity);
        }

        [TestMethod]
        [Description("Should be throw an error")]
        [ExpectedException(typeof(LessThanZeroException))]
        public void QuantityDownWithNegativeValueTest()
        {
            var comic = ComicInventoryBuilder.Create()
                                             .WithQuantity(1)
                                             .Build();

            comic.QuantityDown(-1);
        }

        [TestMethod]
        [Description("Should be throw an custom exception if quantity down is greater thant actual quantity")]
        [ExpectedException(typeof(CustomException))]
        public void QuantityDownGreaterThanActualQuantityThrowsCustomException()
        {
            var comic = ComicInventoryBuilder.Create()
                                             .WithQuantity(0)
                                             .Build();

            comic.QuantityDown(1);
        }

        [TestMethod]
        [Description("Should be throw a LessThanZeroException exception with negative quantity on set property")]
        [ExpectedException(typeof(LessThanZeroException))]
        public void NegativeQuantityDownThrowsLessThanZeroException()
        {
            ComicInventoryBuilder.Create()
                                 .WithQuantity(-1)
                                 .Build();
        }
    }
}