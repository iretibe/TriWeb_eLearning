using eLearning.Domain.Enums;
using MediatR;

namespace eLearning.Application.Commands
{
    public record SubscribeUserCommand(string UserId, SubscriptionType Type) : IRequest;
}
