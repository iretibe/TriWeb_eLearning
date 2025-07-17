namespace eLearning.Domain.Repositories
{
    public interface IPaymentGatewayService
    {
        Task<string> InitializePaystackAsync(string email, int amount, string reference, string callbackUrl);
        Task<bool> VerifyPaystackTransactionAsync(string reference);
    }
}
