using eLearning.Application.Queries;
using eLearning.Domain.Dtos;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class GetAllCourseVideosQueryHandler : IRequestHandler<GetAllCourseVideosQuery, List<VideoContentDto>>
    {
        private readonly IVideoContentService _service;

        public GetAllCourseVideosQueryHandler(IVideoContentService service) => _service = service;

        public async Task<List<VideoContentDto>> Handle(GetAllCourseVideosQuery request, CancellationToken cancellationToken)
        {
            var courses = await _service.GetAllVideoCoursesAsync();

            return courses?.ToList() ?? new List<VideoContentDto>();
        }
    }
}