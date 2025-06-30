using eLearning.WebApp.Client.Models;

namespace eLearning.WebApp.Client.Services
{
    public interface IOrderService
    {
        Task<Guid> CreateOrderAsync(SubscriptionOrderModel order);
        Task MarkOrderAsPaidAsync(Guid orderId, string transactionRef);
        Task<Guid> CreateOneTimePurchaseOrderAsync(string userId, List<CourseModel> courses, string reference);
        Task<List<OrderModel>> GetAllOneTimePurchaseOrdersAsync();
        Task<List<OrderModel>> GetOneTimePurchaseOrdersByUserIdAsync(string userId);
        Task<Guid> GetOrderIdByReferenceAsync(string reference);
    }
}
