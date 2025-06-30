using MediatR;

namespace eLearning.Application.Queries
{
    public record CalculateCourseRatingQuery(Guid CourseId) : IRequest<double>;
}
