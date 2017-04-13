using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp
{
    public interface IPaymentService
    {
        bool ChargePayment(string creditCardNumber, decimal amount);
    }
}
