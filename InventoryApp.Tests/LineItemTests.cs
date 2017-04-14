using InventoryApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InventoryApp.Tests
{
    [TestClass]
    public class LineItemTests
    {
        [TestMethod]
        public void CalculateSubtotal()
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

            decimal expectedSubtotal = 9;

            //Act
            var actualSubtotal = item.Subtotal;

            //Assert
            Assert.AreEqual(expectedSubtotal, actualSubtotal);
        }
    }
}