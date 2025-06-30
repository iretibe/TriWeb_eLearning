using MediatR;

namespace eLearning.Application.Queries
{
    public record GetCourseReviewCountQuery(Guid CourseId) : IRequest<int>;
}
