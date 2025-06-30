using eLearning.Domain.Dtos;
using MediatR;

namespace eLearning.Application.Queries
{
    public record GetOneTimePurchaseOrdersByUserIdQuery(string UserId) : IRequest<List<OrderDto>>;
}
