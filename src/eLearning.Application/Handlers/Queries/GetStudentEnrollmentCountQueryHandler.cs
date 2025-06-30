using eLearning.Application.Queries;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class GetStudentEnrollmentCountQueryHandler : IRequestHandler<GetStudentEnrollmentCountQuery, int>
    {
        private readonly ICourseService _service;

        public GetStudentEnrollmentCountQueryHandler(ICourseService service) => _service = service;

        public async Task<int> Handle(GetStudentEnrollmentCountQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetStudentEnrollmentCountAsync(request.CourseId);
        }
    }
}
