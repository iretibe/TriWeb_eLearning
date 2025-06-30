using eLearning.Application.Exceptions;
using eLearning.Application.Queries;
using eLearning.Domain.Dtos;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class GetCoursesByIdQueryHandler : IRequestHandler<GetCoursesByIdQuery, CourseDto>
    {
        private readonly ICourseService _service;

        public GetCoursesByIdQueryHandler(ICourseService service) => _service = service;

        public async Task<CourseDto> Handle(GetCoursesByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _service.GetCourseByIdAsync(request.Id);

            if (course == null) 
                throw new CourseIdNotFoundException(request.Id);

            return course;
        }
    }
}
