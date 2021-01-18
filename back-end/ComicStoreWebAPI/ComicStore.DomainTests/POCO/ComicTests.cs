using ComicStore.DomainTests.Patterns.Builder;
using ComicStore.Shared.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ComicStore.Domain.POCO.Tests
{
    [TestClass()]
    public class ComicTests
    {
        [TestMethod]
        [Description("Should be throw an LessThanZeroException")]
        [ExpectedException(typeof(LessThanZeroException))]
        public void NegativePagesValue()
        {
            ComicBuilder.Create()
                        .WithPages(-1)
                        .Build();
        }

        [TestMethod]
        [Description("Should be throw an EqualZeroException")]
        [ExpectedException(typeof(EqualZeroException))]
        public void ZeroPagesValue()
        {
            ComicBuilder.Create()
                        .WithPages(0)
                        .Build();
        }

        [TestMethod]
        [Description("Should be throw an LessThanZeroException")]
        [ExpectedException(typeof(LessThanZeroException))]
        public void NegativeYearValue()
        {
            ComicBuilder.Create()
                        .WithYear(-1)
                        .Build();
        }

        [TestMethod]
        [Description("Should be throw an EqualZeroException")]
        [ExpectedException(typeof(EqualZeroException))]
        public void ZeroYearValue()
        {
            ComicBuilder.Create()
                        .WithYear(0)
                        .Build();
        }

        [TestMethod]
        [Description("Should be throw an GreaterThanCurrentDateException")]
        [ExpectedException(typeof(GreaterThanCurrentDateException))]
        public void GreaterThanCurrentYear()
        {
            ComicBuilder.Create()
                        .WithYear(DateTime.UtcNow.Year + 1)
                        .Build();
        }

        [TestMethod]
        [Description("Should be throw an LessThanZeroException")]
        [ExpectedException(typeof(LessThanZeroException))]
        public void NegativePriceValue()
        {
            ComicBuilder.Create()
                        .WithPrice(-1M)
                        .Build();
        }

        [TestMethod]
        [Description("Should be throw an EqualZeroException")]
        [ExpectedException(typeof(EqualZeroException))]
        public void ZeroPriceValue()
        {
            ComicBuilder.Create()
                        .WithPrice(0M)
                        .Build();
        }
    }
}