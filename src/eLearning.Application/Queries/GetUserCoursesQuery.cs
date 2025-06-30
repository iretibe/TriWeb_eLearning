using eLearning.Domain.Dtos;
using MediatR;

namespace eLearning.Application.Queries
{
    public record GetUserCoursesQuery(string UserId) : IRequest<List<CourseDto>>;
}
