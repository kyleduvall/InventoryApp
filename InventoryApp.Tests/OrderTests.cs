using InventoryApp.Models;
using InventoryApp.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace InventoryApp.Tests
{
    [TestClass]
    public class OrderTests
    {
        private IOrder _order;

        [TestInitialize]
        public void Initialize()
        {
            var item = new LineItem()
            {
                Product = new Product()
                {
                    Cost = 3m
                },
                Quantity = 3
            };

            _order = new Order()
            {
                LineItems = new List<LineItem>()
            };

            for (int i = 0; i < 5; i++)
            {
                _order.LineItems.Add(item);
            }
        }

        [TestMethod]
        public void CalculateTotal()
        {
            //Arrange
            decimal expectedTotal = 45m;

            //Act
            decimal actualTotal = _order.Total;

            //Assert
            Assert.AreEqual(expectedTotal, actualTotal);
        }

        [TestMethod]
        public void CheckOrderInStock()
        {
            //Arrange
            var repositoryMock = new Mock<IInventoryRepository>();
            repositoryMock.Setup(r => r.CheckInventory(It.IsAny<string>(), It.IsAny<int>())).Returns(true);
            var repository = repositoryMock.Object;

            //Act
            bool isInStock = _order.InStock(repository);

            //Assert
            Assert.IsTrue(isInStock);
        }

        [TestMethod]
        public void CheckOrderOutOfStock()
        {
            //Arrange
            var repositoryMock = new Mock<IInventoryRepository>();
            repositoryMock.Setup(r => r.CheckInventory(It.IsAny<string>(), It.IsAny<int>())).Returns(false);
            var repository = repositoryMock.Object;

            //Act
            bool isInStock = _order.InStock(repository);

            //Assert
            Assert.IsFalse(isInStock);
        }
    }
}