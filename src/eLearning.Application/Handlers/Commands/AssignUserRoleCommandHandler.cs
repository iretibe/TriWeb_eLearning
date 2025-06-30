using eLearning.Application.Commands;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Commands
{
    public class AssignUserRoleCommandHandler : IRequestHandler<AssignUserRoleCommand>
    {
        private readonly IUserService _service;

        public AssignUserRoleCommandHandler(IUserService service) => _service = service;

        public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
        {
            await _service.AssignRoleAsync(request.UserId, request.Role);
        }
    }
}
