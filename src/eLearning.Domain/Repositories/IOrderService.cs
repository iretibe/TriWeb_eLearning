using eLearning.Domain.Dtos;
using eLearning.Domain.Entities;

namespace eLearning.Domain.Repositories
{
    public interface IOrderService
    {
        //For subscription orders
        Task<Guid> CreateOrderAsync(SubscriptionOrder order);
        Task MarkOrderAsPaidAsync(Guid orderId, string transactionRef);


        // For one-time purchase orders
        Task<Guid> CreateOneTimePurchaseOrderAsync(string userId, List<CourseDto> courses, string reference);
        Task<List<OrderDto>> GetAllOneTimePurchaseOrdersAsync();
        Task<List<OrderDto>> GetOneTimePurchaseOrdersByUserIdAsync(string userId);
        Task<Guid> GetOrderIdByReferenceAsync(string reference);
    }
}
