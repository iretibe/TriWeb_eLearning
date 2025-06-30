using MediatR;

namespace eLearning.Application.Queries
{
    public record GetUserRolesQuery(string UserId) : IRequest<List<string>>;
}
