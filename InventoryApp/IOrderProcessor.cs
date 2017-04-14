using InventoryApp.Models;

namespace InventoryApp
{
    public interface IOrderProcessor
    {
        bool SubmitOrder(IOrder order);
    }
}