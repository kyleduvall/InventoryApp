using InventoryApp.Repositories;
using System.Collections.Generic;

namespace InventoryApp.Models
{
    public interface IOrder
    {
        int OrderId { get; set; }
        string CreditCardNumber { get; set; }
        decimal Total { get; }
        List<LineItem> LineItems { get; set; }

        bool InStock(IInventoryRepository repository);
    }
}