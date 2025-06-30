using MediatR;

namespace eLearning.Application.Queries
{
    public record GetReviewCountQuery(Guid CourseId) : IRequest<int>;
}
