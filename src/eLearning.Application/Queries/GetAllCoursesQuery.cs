using eLearning.Domain.Dtos;
using MediatR;

namespace eLearning.Application.Queries
{
    public record GetAllCoursesQuery : IRequest<List<CourseDto>>;
}
