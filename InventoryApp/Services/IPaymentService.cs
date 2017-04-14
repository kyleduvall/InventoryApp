namespace InventoryApp.Services
{
    public interface IPaymentService
    {
        bool ChargePayment(string creditCardNumber, decimal amount);
    }
}