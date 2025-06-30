using MediatR;

namespace eLearning.Application.Queries
{
    public record GetOrderIdByReferenceQuery(string reference) : IRequest<Guid>;
}
