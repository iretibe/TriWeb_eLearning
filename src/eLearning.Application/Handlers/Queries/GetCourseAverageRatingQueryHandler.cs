using eLearning.Application.Queries;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class GetCourseAverageRatingQueryHandler : IRequestHandler<GetCourseAverageRatingQuery, double>
    {
        private readonly ICourseReviewService _service;

        public GetCourseAverageRatingQueryHandler(ICourseReviewService service) => _service = service;

        public async Task<double> Handle(GetCourseAverageRatingQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAverageRatingAsync(request.CourseId);
        }
    }
}
