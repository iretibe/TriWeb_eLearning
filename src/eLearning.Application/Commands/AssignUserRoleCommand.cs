using MediatR;

namespace eLearning.Application.Commands
{
    public record AssignUserRoleCommand(string UserId, string Role) : IRequest;
}
