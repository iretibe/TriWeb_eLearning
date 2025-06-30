using MediatR;

namespace eLearning.Application.Queries
{
    public record GetCourseAverageRatingQuery(Guid CourseId) : IRequest<double>;
}
