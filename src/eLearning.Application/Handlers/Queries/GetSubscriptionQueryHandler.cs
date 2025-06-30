using eLearning.Application.Queries;
using eLearning.Domain.Dtos;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class GetSubscriptionQueryHandler : IRequestHandler<GetSubscriptionQuery, SubscriptionDto?>
    {
        private readonly ISubscriptionService _service;

        public GetSubscriptionQueryHandler(ISubscriptionService service) => _service = service;

        public async Task<SubscriptionDto?> Handle(GetSubscriptionQuery request, CancellationToken cancellationToken)
            => await _service.GetSubscriptionAsync(request.UserId);
    }
}
