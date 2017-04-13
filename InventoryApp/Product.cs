using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp
{
    public class Product
    {
        public virtual int ProductId { get; set; }
        public string ProductName { get; set; }
        public virtual decimal Cost { get; set; }
    }
}
