using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp
{
    public interface IOrderProcessor
    {
        bool SubmitOrder(Order order);
    }
}
