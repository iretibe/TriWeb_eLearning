namespace eLearning.WebApp.Client.Services
{
    public interface IPaymentService
    {
        Task<string> InitializePaystackAsync(string email, int amountInKobo, string reference);
        Task<bool> VerifyPaystackTransactionAsync(string reference);
    }
}
