using eLearning.Application.Queries;
using eLearning.Domain.Dtos;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class GetAllOneTimePurchaseOrdersQueryHandler : IRequestHandler<GetAllOneTimePurchaseOrdersQuery, List<OrderDto>>
    {
        private readonly IOrderService _orderService;

        public GetAllOneTimePurchaseOrdersQueryHandler(IOrderService orderService) => _orderService = orderService;

        public async Task<List<OrderDto>> Handle(GetAllOneTimePurchaseOrdersQuery request, CancellationToken cancellationToken)
            => await _orderService.GetAllOneTimePurchaseOrdersAsync();
    }
}
