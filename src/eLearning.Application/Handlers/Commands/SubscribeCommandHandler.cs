using eLearning.Application.Commands;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Commands
{
    public class SubscribeCommandHandler : IRequestHandler<SubscribeCommand>
    {
        private readonly ISubscriptionService _service;

        public SubscribeCommandHandler(ISubscriptionService service) => _service = service;

        public async Task Handle(SubscribeCommand request, CancellationToken cancellationToken)
        {
            await _service.SubscribeAsync(request.UserId, request.Type);
        }
    }
}
