using eLearning.WebApp.Client.Models;
using eLearning.WebApp.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace eLearning.WebApp.Client.Services
{
    public class PaymentClientService : IPaymentService
    {
        private readonly HttpClient _http;
        private readonly string _paystackSecretKey;
        private readonly JsonSerializerOptions _jsonOptions;

        public PaymentClientService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _paystackSecretKey = configuration["PayStackSettings:PayStackSecretKey"]
                             ?? throw new InvalidOperationException("Paystack secret key is missing");

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        //public async Task<string> InitializePaystackAsync(string email, int amountInKobo, string reference)
        //{
        //    var payload = new
        //    {
        //        Email = email,
        //        AmountInKobo = amountInKobo,
        //        Reference = reference
        //    };

        //    var response = await _http.PostAsJsonAsync("https://localhost:7012/api/payments/InitializePayment", payload);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var result = await response.Content.ReadFromJsonAsync<PaystackInitResponse>();

        //        if (result != null && !string.IsNullOrEmpty(result.AuthorizationUrl))
        //        {
        //            return result.AuthorizationUrl;
        //        }

        //        throw new Exception("Paystack init failed: Empty authorization URL.");
        //    }
        //    else
        //    {
        //        var error = await response.Content.ReadAsStringAsync();
        //        throw new Exception($"Paystack init failed: {error}");
        //    }
        //}

        public async Task<string> InitializePaystackAsync(string email, int amountInKobo, string reference)
        {
            var request = new
            {
                email = email,
                amount = amountInKobo * 100, // Amount in kobo
                reference = reference,
                callback_url = "https://localhost:7212/checkout-confirm"
            };

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _paystackSecretKey);

            var response = await client.PostAsJsonAsync("https://api.paystack.co/transaction/initialize", request);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<PaystackInitModel>();
            return result?.Data?.AuthorizationUrl ?? throw new Exception("Paystack checkout URL not found.");
        }

        public async Task<bool> VerifyPaystackTransactionAsync(string reference)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _paystackSecretKey);

            var response = await client.GetAsync($"https://api.paystack.co/transaction/verify/{reference}");

            if (!response.IsSuccessStatusCode)
                return false;

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PaystackVerifyModel>(content, _jsonOptions);

            return result?.Data?.Status == "success";
        }
    }
}
