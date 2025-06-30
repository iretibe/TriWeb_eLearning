using eLearning.Domain.Enums;
using MediatR;

namespace eLearning.Application.Commands
{
    public class SubscribeCommand : IRequest
    {
        public string UserId { get; set; } = default!;
        public SubscriptionType Type { get; set; }
    }
}
