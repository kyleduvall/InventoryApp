using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InventoryApp.Tests
{
    [TestClass]
    public class LineItemTests
    {
        [TestMethod]
        public void CalculateCost()
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

            decimal expectedCost = 9;

            //Act
            var actualCost = item.Subtotal;

            //Assert
            Assert.AreEqual(expectedCost, actualCost);
        }
    }
}
