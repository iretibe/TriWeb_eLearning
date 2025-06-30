using eLearning.Application.Queries;
using eLearning.Domain.Dtos;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class GetUserCoursesQueryHandler : IRequestHandler<GetUserCoursesQuery, List<CourseDto>>
    {
        private readonly ICourseService _repository;

        public GetUserCoursesQueryHandler(ICourseService repository)
        {
            _repository = repository;
        }

        public async Task<List<CourseDto>> Handle(GetUserCoursesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetUserCoursesAsync(request.UserId);
        }
    }
}
