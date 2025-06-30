using eLearning.Application.Queries;
using eLearning.Domain.Dtos;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<ApplicationUserDto>>
    {
        private readonly IUserService _service;

        public GetAllUsersQueryHandler(IUserService service) => _service = service;

        public async Task<List<ApplicationUserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _service.GetAllUsersAsync();

            return users.ToList();
        }
    }
}
