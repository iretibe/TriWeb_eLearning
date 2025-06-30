using eLearning.Domain.Dtos;
using MediatR;

namespace eLearning.Application.Queries
{
    public record GetAllOneTimePurchaseOrdersQuery() : IRequest<List<OrderDto>>;
}
