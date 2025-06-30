using eLearning.Application.Queries;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class CalculateCourseRatingQueryHandler : IRequestHandler<CalculateCourseRatingQuery, double>
    {
        private readonly ICourseService _service;

        public CalculateCourseRatingQueryHandler(ICourseService service) => _service = service;

        public async Task<double> Handle(CalculateCourseRatingQuery request, CancellationToken cancellationToken)
        {
            return await _service.CalculateCourseRatingAsync(request.CourseId);
        }
    }
}
