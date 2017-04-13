using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp
{
    public class LineItem
    {
        public virtual Product Product { get; set; }
        public virtual int Quantity { get; set; }

        public virtual decimal Subtotal
        {
            get
            {
                return Product.Cost * Quantity;
            }
        }
    }
}
