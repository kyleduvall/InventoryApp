using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace InventoryApp.Tests
{
    [TestClass]
    public class OrderProcessorTests
    {
        [TestMethod]
        public void SubmitOrderItemInStock()
        {
            //Arrange
            var repositoryMock = new Mock<IInventoryRepository>();
            repositoryMock.Setup(r => r.CheckInventory(It.IsAny<string>(), It.IsAny<int>())).Returns(true);
            var repository = repositoryMock.Object;

            var paymentServiceMock = new Mock<IPaymentService>();
            paymentServiceMock.Setup(p => p.ChargePayment(It.IsAny<string>(), It.IsAny<decimal>())).Returns(true);
            var paymentService = paymentServiceMock.Object;

            //TODO: Change from Mocks to actual objects to remove virtuals
            var productMock = new Mock<Product>();
            productMock.SetupGet(p => p.ProductId).Returns(1);
            productMock.SetupGet(p => p.Cost).Returns(1);
            var product = productMock.Object;

            var lineItemMock = new Mock<LineItem>();
            lineItemMock.SetupGet(l => l.Product).Returns(product);
            lineItemMock.SetupGet(l => l.Quantity).Returns(1);
            lineItemMock.SetupGet(l => l.Subtotal).Returns(20);
            var lineItem = lineItemMock.Object;

            var orderMock = new Mock<Order>();
            orderMock.SetupGet(o => o.LineItems).Returns(new List<LineItem>() { lineItem, lineItem, lineItem, lineItem, lineItem });
            orderMock.SetupGet(o => o.Total).Returns(100);
            var order = orderMock.Object;

            var orderProcessor = new OrderProcessor(repository, paymentService);

            //Act
            bool isSuccess = orderProcessor.SubmitOrder(order);
            
            //Assess
            Assert.IsTrue(isSuccess);
        }
    }
}
