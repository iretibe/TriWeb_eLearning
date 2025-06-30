using eLearning.Application.Queries;
using eLearning.Domain.Dtos;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class GetCourseReviewsQueryHandler : IRequestHandler<GetCourseReviewsQuery, List<CourseReviewDto>>
    {
        private readonly ICourseReviewService _service;

        public GetCourseReviewsQueryHandler(ICourseReviewService service) => _service = service;

        public async Task<List<CourseReviewDto>> Handle(GetCourseReviewsQuery request, CancellationToken cancellationToken)
        {
            return (await _service.GetReviewsByCourseAsync(request.CourseId)).ToList();
        }
    }
}
