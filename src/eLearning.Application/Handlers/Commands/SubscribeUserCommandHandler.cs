using eLearning.Application.Commands;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Commands
{
    public class SubscribeUserCommandHandler : IRequestHandler<SubscribeUserCommand>
    {
        private readonly ISubscriptionService _service;

        public SubscribeUserCommandHandler(ISubscriptionService service)
        {
            _service = service;
        }

        public async Task Handle(SubscribeUserCommand request, CancellationToken cancellationToken)
        {
            await _service.SubscribeAsync(request.UserId, request.Type);
        }
    }
}
