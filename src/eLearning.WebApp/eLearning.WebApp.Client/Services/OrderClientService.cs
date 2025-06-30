using eLearning.WebApp.Client.Models;
using System.Net.Http.Json;

namespace eLearning.WebApp.Client.Services
{
    public class OrderClientService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
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

            var response = await _httpClient.PostAsJsonAsync("api/Orders/CreateOneTimePurchaseOrder", order);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Guid>();
        }

        public async Task<Guid> CreateOrderAsync(SubscriptionOrderModel order)
        {
            order.Status = "Paid"; // Ensure the order status is set to Pending
            order.OrderDate = DateTime.UtcNow; // Set the order date to current UTC time
            var response = await _httpClient.PostAsJsonAsync("api/Orders/CreateOrder", order);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Guid>();
        }

        public async Task<List<OrderModel>> GetAllOneTimePurchaseOrdersAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7012/api/Orders/GetAllOneTimePurchaseOrders");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<OrderModel>>() ?? new();
        }

        public async Task<List<OrderModel>> GetOneTimePurchaseOrdersByUserIdAsync(string userId)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7012/api/Orders/GetOneTimePurchaseOrdersByUserId/{userId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<OrderModel>>() ?? new();
        }

        public async Task<Guid> GetOrderIdByReferenceAsync(string reference)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7012/api/Orders/GetOrderIdByReference/{reference}");
            return await response.Content.ReadFromJsonAsync<Guid>();
        }

        public async Task MarkOrderAsPaidAsync(Guid orderId, string transactionRef)
        {
            var command = new { OrderId = orderId, TransactionReference = transactionRef };
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7012/api/Orders/MarkOrderAsPaid", command);
            response.EnsureSuccessStatusCode();
        }
    }
}
