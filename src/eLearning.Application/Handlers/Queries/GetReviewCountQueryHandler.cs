using eLearning.Application.Queries;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class GetReviewCountQueryHandler : IRequestHandler<GetReviewCountQuery, int>
    {
        private readonly ICourseService _service;

        public GetReviewCountQueryHandler(ICourseService service) => _service = service;

        public async Task<int> Handle(GetReviewCountQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetReviewCountAsync(request.CourseId);
        }
    }
}
