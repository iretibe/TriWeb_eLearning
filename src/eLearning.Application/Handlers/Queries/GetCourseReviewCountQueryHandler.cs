using eLearning.Application.Queries;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class GetCourseReviewCountQueryHandler : IRequestHandler<GetCourseReviewCountQuery, int>
    {
        private readonly ICourseReviewService _service;

        public GetCourseReviewCountQueryHandler(ICourseReviewService service) => _service = service;

        public async Task<int> Handle(GetCourseReviewCountQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetTotalReviewCountAsync(request.CourseId);
        }
    }
}
