namespace InventoryApp.Services
{
    public interface IEmailService
    {
        bool SendEmail(string toAddress, string fromAddress, string subject, string body);
    }
}