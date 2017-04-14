using InventoryApp.Models;
using InventoryApp.Repositories;
using InventoryApp.Services;
using System;

namespace InventoryApp
{
    public class OrderProcessor : IOrderProcessor
    {
        private IInventoryRepository _repository;
        private IPaymentService _paymentService;
        private IEmailService _emailService;
        private const string FROM_ADDRESS = "noreply@company.com";
        private const string TO_ADDRESS = "shipping@company.com";

        public OrderProcessor(IInventoryRepository repository, IPaymentService paymentService, IEmailService emailService)
        {
            _repository = repository;
            _paymentService = paymentService;
            _emailService = emailService;
        }

        public bool SubmitOrder(IOrder order)
        {
            if (order == null)
            {
                throw new ArgumentException(nameof(order));
            }

            if(!order.InStock(_repository))
            {
                return false;
            }

            if (_paymentService.ChargePayment(order.CreditCardNumber, order.Total))
            {
                bool emailSent = _emailService.SendEmail(FROM_ADDRESS, TO_ADDRESS, string.Empty, string.Empty);

                if (!emailSent)
                {
                    //TODO: Capture in companies logging system
                    Console.WriteLine($"Email failed to send! Order # {order.OrderId}");
                }

                return true;
            }

            return false;
        }
    }
}