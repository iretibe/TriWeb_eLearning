using eLearning.Application.Queries;
using eLearning.Domain.Dtos;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class GetVideosByCourseQueryHandler : IRequestHandler<GetVideosByCourseQuery, List<VideoContentDto>>
    {
        private readonly IVideoContentService _service;

        public GetVideosByCourseQueryHandler(IVideoContentService service) => _service = service;

        public async Task<List<VideoContentDto>> Handle(GetVideosByCourseQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetVideosByCourseAsync(request.CourseId);
        }
    }
}
