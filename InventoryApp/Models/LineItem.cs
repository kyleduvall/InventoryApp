namespace InventoryApp.Models
{
    public class LineItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public decimal Subtotal
        {
            get
            {
                return Product.Cost * Quantity;
            }
        }
    }
}