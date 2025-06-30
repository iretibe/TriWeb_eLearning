using eLearning.Application.Queries;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class IsUserSubscribedQueryHandler : IRequestHandler<IsUserSubscribedQuery, bool>
    {
        private readonly ISubscriptionService _service;

        public IsUserSubscribedQueryHandler(ISubscriptionService service) => _service = service;

        public async Task<bool> Handle(IsUserSubscribedQuery request, CancellationToken cancellationToken)
        {
            return await _service.IsSubscribedAsync(request.UserId);
        }
    }
}
