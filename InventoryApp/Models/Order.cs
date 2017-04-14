using InventoryApp.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace InventoryApp.Models
{
    public class Order : IOrder
    {
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreditCardNumber { get; set; }
        public List<LineItem> LineItems { get; set; }

        public decimal Total
        {
            get
            {
                return LineItems.Sum(o => o.Subtotal);
            }
        }

        public bool InStock(IInventoryRepository repository)
        {
            foreach (var item in LineItems)
            {
                if (!(repository.CheckInventory(item.Product.ProductId.ToString(), item.Quantity)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}