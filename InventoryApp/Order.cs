using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp
{
    public class Order
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreditCardNumber { get; set; }
        public virtual List<LineItem> LineItems { get; set; }
        public virtual decimal Total
        {
            get
            {
                return LineItems.Sum(o => o.Subtotal);
            }
        }
    }
}
