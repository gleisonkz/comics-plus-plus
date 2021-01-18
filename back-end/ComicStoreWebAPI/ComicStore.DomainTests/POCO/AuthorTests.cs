using ComicStore.DomainTests.Patterns.Builder;
using ComicStore.Shared.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ComicStore.Domain.POCO.Tests
{
    [TestClass()]
    public class AuthorTests
    {

        [TestMethod]
        [Description("Should be throw an GreaterThanCurrentDateException")]
        [ExpectedException(typeof(GreaterThanCurrentDateException))]
        public void GreaterThanCurrentDate()
        {
            AuthorBuilder.Create()
                         .WithBirthDate(DateTime.UtcNow.AddYears(1))
                         .Build();
        }
    }
}