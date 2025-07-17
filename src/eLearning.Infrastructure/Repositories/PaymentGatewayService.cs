using eLearning.Domain.Dtos;
using eLearning.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace eLearning.Infrastructure.Repositories
{
    public class PaymentGatewayService : IPaymentGatewayService
    {
        private readonly HttpClient _httpClient;
        private readonly string _paystackSecretKey;
        private readonly string _initializationUrl;
        private readonly string _verificationUrl;
        private readonly JsonSerializerOptions _jsonOptions;
        private readonly IConfiguration _configuration;

        public PaymentGatewayService(IConfiguration configuration)
        {
            _configuration = configuration;

            _paystackSecretKey = $"{_configuration["PayStackSettings:PayStackSecretKey"]}";
            _initializationUrl = $"{_configuration["PayStackSettings:PayStackInitializationUrl"]}";
            _verificationUrl = $"{_configuration["PayStackSettings:PayStackVerificationUrl"]}";
            _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _paystackSecretKey);
        }

        public async Task<string> InitializePaystackAsync(string email, int amount, string reference, string callbackUrl)
        {
            var payload = new
            {
                email,
                amount = amount * 100, // Paystack expects kobo
                currency = "GHS",
                reference,
                callback_url = callbackUrl
            };

            var response = await _httpClient.PostAsJsonAsync(_initializationUrl, payload);

            // Debugging - Check raw response
            var rawResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Paystack Init Response: {rawResponse}");

            if (!response.IsSuccessStatusCode)
            {
                // Log the error or throw an exception
                throw new Exception($"Paystack initialization failed: {rawResponse}");
            }

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<PaystackInitDto>(_jsonOptions);
            return result?.Data?.AuthorizationUrl ?? throw new Exception("Paystack checkout URL not found.");
        }

        public async Task<bool> VerifyPaystackTransactionAsync(string reference)
        {
            var response = await _httpClient.GetAsync($"{_verificationUrl}/{reference}");
            if (!response.IsSuccessStatusCode)
                return false;

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PaystackVerifyNewDto>(content, _jsonOptions);

            return result?.Data?.Status == "success";
        }
    }
}
