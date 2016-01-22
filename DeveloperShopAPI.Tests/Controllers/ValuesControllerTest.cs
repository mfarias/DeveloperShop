using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeveloperShopAPI;
using DeveloperShopAPI.Controllers;
using DeveloperShopAPI.Models;

namespace DeveloperShopAPI.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            ShopController controller = new ShopController();

            // Act
            ShopCart result = controller.GetShopCart();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Developers.Count());
            Assert.AreEqual("mfarias", result.Developers.ElementAt(0).Username);
        }

        //[TestMethod]
        //public void GetById()
        //{
        //    // Arrange
        //    ShopController controller = new ShopController();

        //    // Act
        //    string result = controller.Get(5);

        //    // Assert
        //    Assert.AreEqual("value", result);
        //}

        //[TestMethod]
        //public void Post()
        //{
        //    // Arrange
        //    ShopController controller = new ShopController();

        //    // Act
        //    controller.Post("value");

        //    // Assert
        //}

        //[TestMethod]
        //public void Put()
        //{
        //    // Arrange
        //    ShopController controller = new ShopController();

        //    // Act
        //    controller.Put(5, "value");

        //    // Assert
        //}

        //[TestMethod]
        //public void Delete()
        //{
        //    // Arrange
        //    ShopController controller = new ShopController();

        //    // Act
        //    controller.Delete(5);

        //    // Assert
        //}
    }
}
