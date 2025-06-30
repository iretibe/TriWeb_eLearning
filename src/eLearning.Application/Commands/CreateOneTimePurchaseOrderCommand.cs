using eLearning.Domain.Dtos;
using MediatR;

namespace eLearning.Application.Commands
{
    public record CreateOneTimePurchaseOrderCommand(OrderDto Order) : IRequest<Guid>;
}
