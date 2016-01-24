using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeveloperShop.Domain.Entities;
using SharpTestsEx;

namespace DeveloperShop.UnitTests
{
    [TestClass]
    public class DeveloperPriceTests
    {
        [TestMethod]
        public void TheLowerPriceForDeveloperShouldBeDefined()
        {
            new Developer().Price.Should().Be(25.5d);
        }

        [TestMethod]
        public void ShouldBePossibleToCalculateDeveloperPrice()
        {
            var dev = new Developer { Followers = 10, Stars = 20, Watchers = 5 };

            dev.Price.Should().Be(100.5d);
        }
    }
}
