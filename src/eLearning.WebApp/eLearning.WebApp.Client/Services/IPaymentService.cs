namespace eLearning.WebApp.Client.Services
{
    public interface IPaymentService
    {
        //Task<string> InitializePaystackAsync(string email, int amountInKobo, string reference);
        Task<string> InitializePaystackAsync(string email, int amountInKobo, string reference, string callbackUrl);
        Task<bool> VerifyPaystackTransactionAsync(string reference);

        Task<string> InitializePaymentAsync(string email, int amount, string reference, string callbackUrl);
        //Task<string> InitializePaymentAsync(InitializePaymentRequestModel model);
        Task<bool> VerifyPaymentAsync(string reference);
    }
}
