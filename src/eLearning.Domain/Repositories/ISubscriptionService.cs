using eLearning.Domain.Dtos;
using eLearning.Domain.Enums;

namespace eLearning.Domain.Repositories
{
    public interface ISubscriptionService
    {
        Task SubscribeAsync(string userId, SubscriptionType type);
        Task<SubscriptionDto?> GetSubscriptionAsync(string userId);
        Task<bool> IsSubscribedAsync(string userId);
    }
}
