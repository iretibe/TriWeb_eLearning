using eLearning.Application.Queries;
using eLearning.Domain.Dtos;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class GetOneTimePurchaseOrdersByUserIdQueryHandler : IRequestHandler<GetOneTimePurchaseOrdersByUserIdQuery, List<OrderDto>>
    {
        private readonly IOrderService _orderService;

        public GetOneTimePurchaseOrdersByUserIdQueryHandler(IOrderService orderService) => _orderService = orderService;

        public async Task<List<OrderDto>> Handle(GetOneTimePurchaseOrdersByUserIdQuery request, CancellationToken cancellationToken)
            => await _orderService.GetOneTimePurchaseOrdersByUserIdAsync(request.UserId);
    }
}
