using eLearning.Application.Queries;
using eLearning.Domain.Dtos;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class GetUserSubscriptionQueryHandler : IRequestHandler<GetUserSubscriptionQuery, SubscriptionDto?>
    {
        private readonly ISubscriptionService _service;

        public GetUserSubscriptionQueryHandler(ISubscriptionService service) => _service = service;

        public async Task<SubscriptionDto?> Handle(GetUserSubscriptionQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetSubscriptionAsync(request.UserId);
        }
    }
}
