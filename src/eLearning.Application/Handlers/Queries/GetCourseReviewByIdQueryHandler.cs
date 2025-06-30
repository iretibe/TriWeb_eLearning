using eLearning.Application.Queries;
using eLearning.Domain.Dtos;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class GetCourseReviewByIdQueryHandler : IRequestHandler<GetCourseReviewByIdQuery, CourseReviewDto?>
    {
        private readonly ICourseReviewService _service;

        public GetCourseReviewByIdQueryHandler(ICourseReviewService service) => _service = service;

        public async Task<CourseReviewDto?> Handle(GetCourseReviewByIdQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetReviewByIdAsync(request.ReviewId);
        }
    }
}
