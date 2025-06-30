using eLearning.Application.Queries;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class IsUserEnrolledQueryHandler : IRequestHandler<IsUserEnrolledQuery, bool>
    {
        private readonly IEnrollmentService _service;

        public IsUserEnrolledQueryHandler(IEnrollmentService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(IsUserEnrolledQuery request, CancellationToken cancellationToken)
        {
            return await _service.IsUserEnrolledAsync(request.UserId, request.CourseId);
        }
    }
}
