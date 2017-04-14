namespace InventoryApp.Repositories
{
    public interface IInventoryRepository
    {
        bool CheckInventory(string productId, int qty);
    }
}