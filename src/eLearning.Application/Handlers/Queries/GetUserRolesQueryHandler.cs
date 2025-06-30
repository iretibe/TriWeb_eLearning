using eLearning.Application.Queries;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class GetUserRolesQueryHandler : IRequestHandler<GetUserRolesQuery, List<string>>
    {
        private readonly IUserService _service;

        public GetUserRolesQueryHandler(IUserService service) => _service = service;

        public async Task<List<string>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _service.GetUserRolesAsync(request.UserId);
            return roles.ToList();
        }
    }
}
