using eLearning.Domain.Dtos;
using MediatR;

namespace eLearning.Application.Queries
{
    public class GetSubscriptionQuery : IRequest<SubscriptionDto?>
    {
        public string UserId { get; set; } = default!;
    }
}
