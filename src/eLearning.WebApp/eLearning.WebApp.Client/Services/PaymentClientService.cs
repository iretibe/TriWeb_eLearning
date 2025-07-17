using eLearning.WebApp.Client.Models;
using eLearning.WebApp.Client.Responses;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace eLearning.WebApp.Client.Services
{
    public class PaymentClientService : IPaymentService
    {
        private readonly HttpClient _http;
        private readonly string _backendUrl;
        private readonly string _paystackSecretKey;
        private readonly string _initializationUrl;
        private readonly string _verificationUrl;
        private readonly string _frontendUrl;
        private readonly JsonSerializerOptions _jsonOptions;

        public PaymentClientService(HttpClient http, IConfiguration configuration)
        {
            _http = http;

            _paystackSecretKey = configuration["PayStackSettings:PayStackSecretKey"]
                                 ?? throw new InvalidOperationException("Paystack secret key is missing");

            _initializationUrl = configuration["PayStackSettings:PayStackInitializationUrl"]
                                 ?? throw new InvalidOperationException("Initialization URL is missing");

            _verificationUrl = configuration["PayStackSettings:PayStackVerificationUrl"]
                                 ?? throw new InvalidOperationException("Verification URL is missing");

            _frontendUrl = configuration["ApiUrls:FrontendUrl"]
                                ?? throw new InvalidOperationException("Frontend URL is missing");

            _backendUrl = configuration["ApiUrls:BackendUrl"]
                ?? throw new InvalidOperationException("Backend URL is missing");

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<string> InitializePaymentAsync(string email, int amount, string reference, string callbackUrl)
        {
            var request = new InitializePaymentRequestModel
            {
                Email = email,
                Amount = amount,
                Reference = reference,
                CallbackUrl = callbackUrl
            };

            var response = await _http.PostAsJsonAsync($"{_backendUrl}/api/Payments/InitializePayment", request);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to initialize payment.");

            var result = await response.Content.ReadFromJsonAsync<InitializePaymentResponse>();

            return result?.AuthorizationUrl ?? throw new Exception("Authorization URL missing.");
        }

        //public async Task<string> InitializePaystackAsync(string email, int amountInKobo, string reference)
        //{
        //    var request = new
        //    {
        //        email = email,
        //        amount = amountInKobo * 100, // Amount in kobo
        //        reference = reference,
        //        callback_url = $"{_frontendUrl}/checkout-confirm"
        //    };

        //    var client = new HttpClient();
        //    client.DefaultRequestHeaders.Authorization =
        //        new AuthenticationHeaderValue("Bearer", _paystackSecretKey);

        //    var response = await client.PostAsJsonAsync(_initializationUrl, request);
        //    response.EnsureSuccessStatusCode();

        //    var result = await response.Content.ReadFromJsonAsync<PaystackInitModel>();
        //    return result?.Data?.AuthorizationUrl ?? throw new Exception("Paystack checkout URL not found.");
        //}

        public async Task<string> InitializePaystackAsync(string email, int amountInKobo, string reference, string callbackUrl)
        {
            var request = new
            {
                email = email,
                amount = amountInKobo * 100, // Amount in kobo
                reference = reference,
                callback_url = callbackUrl
            };

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _paystackSecretKey);

            var response = await client.PostAsJsonAsync(_initializationUrl, request);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<PaystackInitModel>();
            return result?.Data?.AuthorizationUrl ?? throw new Exception("Paystack checkout URL not found.");
        }

        public async Task<bool> VerifyPaymentAsync(string reference)
        {
            var response = await _http.GetAsync($"{_backendUrl}/api/Payments/VerifyPayment/{reference}");

            if (!response.IsSuccessStatusCode)
                return false;

            var result = await response.Content.ReadFromJsonAsync<VerifyPaymentResponse>();
            return result?.Success ?? false;
        }

        public async Task<bool> VerifyPaystackTransactionAsync(string reference)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _paystackSecretKey);

            var response = await client.GetAsync($"{_verificationUrl}/{reference}");

            if (!response.IsSuccessStatusCode)
                return false;

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PaystackVerifyModel>(content, _jsonOptions);

            return result?.Data?.Status == "success";
        }
    }
}
