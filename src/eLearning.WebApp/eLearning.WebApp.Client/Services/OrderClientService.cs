using eLearning.WebApp.Client.Models;
using System.Net.Http.Json;

namespace eLearning.WebApp.Client.Services
{
    public class OrderClientService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly string _backendUrl;

        public OrderClientService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _backendUrl = configuration["ApiUrls:BackendUrl"]
                ?? throw new InvalidOperationException("Backend URL is missing");
        }

        public async Task<Guid> CreateOneTimePurchaseOrderAsync(string userId, List<CourseModel> courses, string reference)
        {
            var order = new
            {
                order = new
                {
                    UserId = userId,
                    TotalAmount = courses.Sum(c => c.Price),
                    TransactionReference = reference,
                    OrderDate = DateTime.UtcNow,
                    Items = courses.Select(c => new
                    {
                        CourseId = c.Id,
                        CourseTitle = c.Title,
                        Price = c.Price
                    }).ToList()
                }
            };

            var response = await _httpClient.PostAsJsonAsync($"{_backendUrl}/api/Orders/CreateOneTimePurchaseOrder", order);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Guid>();
        }

        public async Task<Guid> CreateOrderAsync(SubscriptionOrderModel order)
        {
            order.Status = "Paid"; // Ensure the order status is set to Pending
            order.OrderDate = DateTime.UtcNow; // Set the order date to current UTC time
            var response = await _httpClient.PostAsJsonAsync($"{_backendUrl}/api/Orders/CreateOrder", order);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Guid>();
        }

        public async Task<List<OrderModel>> GetAllOneTimePurchaseOrdersAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<OrderModel>>($"{_backendUrl}/api/Orders/GetAllOneTimePurchaseOrders");

            return response ?? new List<OrderModel>();
        }

        public async Task<List<OrderModel>> GetOneTimePurchaseOrdersByUserIdAsync(string userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_backendUrl}/api/Orders/GetOneTimePurchaseOrdersByUserId/{userId}");
                
                response.EnsureSuccessStatusCode();

                var orders = await response.Content.ReadFromJsonAsync<List<OrderModel>>();
                return orders ?? new List<OrderModel>();
            }
            catch (HttpRequestException ex)
            {
                // Log or handle error
                throw new ApplicationException("Failed to load orders.", ex);
            }
        }

        public async Task<Guid> GetOrderIdByReferenceAsync(string reference)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_backendUrl}/api/Orders/GetOrderIdByReference/{reference}");

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<Guid>();
            }
            catch (HttpRequestException ex)
            {
                // Log or handle error
                throw new ApplicationException("Failed to load order.", ex);
            }
        }

        public async Task MarkOrderAsPaidAsync(Guid orderId, string transactionRef)
        {
            var command = new { OrderId = orderId, TransactionReference = transactionRef };
            var response = await _httpClient.PostAsJsonAsync($"{_backendUrl}/api/Orders/MarkOrderAsPaid", command);
            response.EnsureSuccessStatusCode();
        }
    }
}
