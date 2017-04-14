using InventoryApp.Models;
using InventoryApp.Repositories;
using InventoryApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace InventoryApp.Tests
{
    [TestClass]
    public class OrderProcessorTests
    {
        private IInventoryRepository _repository;
        private IPaymentService _paymentService;
        private IEmailService _emailService;

        [TestInitialize]
        public void Initialize()
        {
            var repositoryMock = new Mock<IInventoryRepository>();
            repositoryMock.Setup(r => r.CheckInventory(It.IsAny<string>(), It.IsAny<int>())).Returns(true);
            _repository = repositoryMock.Object;

            var paymentServiceMock = new Mock<IPaymentService>();
            paymentServiceMock.Setup(p => p.ChargePayment(It.IsAny<string>(), It.IsAny<decimal>())).Returns(true);
            _paymentService = paymentServiceMock.Object;

            var emailServiceMock = new Mock<IEmailService>();
            emailServiceMock.Setup(e => e.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            _emailService = emailServiceMock.Object;
        }

        [TestMethod]
        public void SubmitOrderItemInStock()
        {
            //Arrange
            var orderMock = new Mock<IOrder>();
            orderMock.SetupGet(o => o.CreditCardNumber).Returns("1234123412341234");
            orderMock.SetupGet(o => o.Total).Returns(100);
            orderMock.Setup(o => o.InStock(_repository)).Returns(true);
            var order = orderMock.Object;

            var orderProcessor = new OrderProcessor(_repository, _paymentService, _emailService);

            //Act
            bool isSuccess = orderProcessor.SubmitOrder(order);

            //Assess
            Assert.IsTrue(isSuccess);
        }

        [TestMethod]
        public void SubmitOrderItemOutOfStock()
        {
            //Arrange
            var orderMock = new Mock<IOrder>();
            orderMock.SetupGet(o => o.CreditCardNumber).Returns("1234123412341234");
            orderMock.SetupGet(o => o.Total).Returns(100);
            orderMock.Setup(o => o.InStock(_repository)).Returns(false);
            var order = orderMock.Object;

            var orderProcessor = new OrderProcessor(_repository, _paymentService, _emailService);

            //Act
            bool isSuccess = orderProcessor.SubmitOrder(order);

            //Assess
            Assert.IsFalse(isSuccess);
        }
    }
}