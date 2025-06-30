using eLearning.Application.Queries;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class RecalculateCourseStatisticsCommandHandler : IRequestHandler<RecalculateCourseStatisticsCommand>
    {
        private readonly ICourseService _service;

        public RecalculateCourseStatisticsCommandHandler(ICourseService service) => _service = service;

        public async Task Handle(RecalculateCourseStatisticsCommand request, CancellationToken cancellationToken)
        {
            await _service.RecalculateCourseStatisticsAsync(request.CourseId);
        }
    }

}
