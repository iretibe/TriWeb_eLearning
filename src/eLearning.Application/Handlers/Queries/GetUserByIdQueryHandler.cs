using eLearning.Application.Queries;
using eLearning.Domain.Dtos;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ApplicationUserDto?>
    {
        private readonly IUserService _service;

        public GetUserByIdQueryHandler(IUserService service) => _service = service;

        public async Task<ApplicationUserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetUserByIdAsync(request.UserId);
        }
    }
}
