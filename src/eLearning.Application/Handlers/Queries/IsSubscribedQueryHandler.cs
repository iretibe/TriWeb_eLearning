using eLearning.Application.Queries;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class IsSubscribedQueryHandler : IRequestHandler<IsSubscribedQuery, bool>
    {
        private readonly ISubscriptionService _service;

        public IsSubscribedQueryHandler(ISubscriptionService service) => _service = service;

        public async Task<bool> Handle(IsSubscribedQuery request, CancellationToken cancellationToken)
            => await _service.IsSubscribedAsync(request.UserId);
    }
}
