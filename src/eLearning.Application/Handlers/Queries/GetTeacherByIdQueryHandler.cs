using eLearning.Application.Queries;
using eLearning.Domain.Dtos;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class GetTeacherByIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, ApplicationUserDto?>
    {
        private readonly IUserService _service;

        public GetTeacherByIdQueryHandler(IUserService service) => _service = service;

        public async Task<ApplicationUserDto?> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetUserByIdAsync(request.UserId);
        }
    }
}