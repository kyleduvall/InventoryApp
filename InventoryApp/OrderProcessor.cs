using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp
{
    public class OrderProcessor : IOrderProcessor
    {
        private IInventoryRepository _repository;
        private IPaymentService _paymentService;

        public OrderProcessor(IInventoryRepository repository, IPaymentService paymentService)
        {
            _repository = repository;
            _paymentService = paymentService;
        }

        public bool SubmitOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentException("order");
            }

            foreach (var item in order.LineItems)
            {
                if (!(_repository.CheckInventory(item.Product.ProductId.ToString(), item.Quantity)))
                {
                    return false;
                }
            }

            return _paymentService.ChargePayment(order.CreditCardNumber, order.Total);
            //TODO: If charge successfull send email
        }
    }
}
