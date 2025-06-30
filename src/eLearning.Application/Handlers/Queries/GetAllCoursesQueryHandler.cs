using eLearning.Application.Exceptions;
using eLearning.Application.Queries;
using eLearning.Domain.Dtos;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, List<CourseDto>>
    {
        private readonly ICourseService _service;

        public GetAllCoursesQueryHandler(ICourseService service) => _service = service;

        public async Task<List<CourseDto>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _service.GetAllCoursesAsync();

            //if (courses == null || !courses.Any())
            //    throw new CoursesNotFoundException();

            return courses?.ToList() ?? new List<CourseDto>();
        }
    }
}
