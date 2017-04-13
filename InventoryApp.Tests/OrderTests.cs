using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace InventoryApp.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void CalculateTotal()
        {
            //Arrange
            var item = new LineItem()
            {
                Product = new Product()
                {
                    Cost = 3m
                },
                Quantity = 3
            };

            var newOrder = new Order()
            {
                LineItems = new List<LineItem>()
            };

            for (int i = 0; i < 5; i++)
            {
                newOrder.LineItems.Add(item);
            }

            decimal expectedTotal = 45m;

            //Act
            decimal actualTotal = newOrder.Total;

            //Assert
            Assert.AreEqual(expectedTotal, actualTotal);
        }
    }
}
