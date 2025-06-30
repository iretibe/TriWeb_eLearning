using MediatR;

namespace eLearning.Application.Queries
{
    public record IsUserSubscribedQuery(string UserId) : IRequest<bool>;
}
