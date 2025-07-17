using eLearning.Application.Queries;
using eLearning.Domain.Dtos;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    internal class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeachersQuery, List<ApplicationUserDto>>
    {
        private readonly IUserService _service;

        public GetAllTeachersQueryHandler(IUserService service) => _service = service;

        public async Task<List<ApplicationUserDto>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
            var users = await _service.GetAllLecturersAsync();

            return users.ToList();
        }
    }
}

