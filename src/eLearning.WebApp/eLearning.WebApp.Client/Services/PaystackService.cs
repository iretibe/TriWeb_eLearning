using eLearning.WebApp.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace eLearning.WebApp.Client.Services
{
    public class PaystackService
    {
        private readonly HttpClient _http;

        public PaystackService(HttpClient http)
        {
            _http = http;
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "sk_test_xxx"); // 🔐 your secret key
        }

        //public async Task<string> InitializePaymentAsync(PaystackInitRequest request)
        //{
        //    var response = await _http.PostAsJsonAsync("https://api.paystack.co/transaction/initialize", request);
        //    var result = await response.Content.ReadFromJsonAsync<PaystackInitResponse>();

        //    if (result?.Status == true)
        //        return result.Data.AuthorizationUrl;

        //    throw new ApplicationException(result?.Message ?? "Payment failed to initialize.");
        //}
    }
}
