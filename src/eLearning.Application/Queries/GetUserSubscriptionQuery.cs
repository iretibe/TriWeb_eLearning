using eLearning.Domain.Dtos;
using MediatR;

namespace eLearning.Application.Queries
{
    public record GetUserSubscriptionQuery(string UserId) : IRequest<SubscriptionDto?>;
}
