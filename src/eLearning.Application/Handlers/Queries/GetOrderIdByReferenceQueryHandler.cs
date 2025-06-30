using eLearning.Application.Queries;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class GetOrderIdByReferenceQueryHandler : IRequestHandler<GetOrderIdByReferenceQuery, Guid>
    {
        private readonly IOrderService _orderRepository;

        public GetOrderIdByReferenceQueryHandler(IOrderService orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Guid> Handle(GetOrderIdByReferenceQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderIdByReferenceAsync(request.reference);
           
            return order;
        }
    }
}
