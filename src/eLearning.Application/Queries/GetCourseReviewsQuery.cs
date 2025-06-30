using eLearning.Domain.Dtos;
using MediatR;

namespace eLearning.Application.Queries
{
    public record GetCourseReviewsQuery(Guid CourseId) : IRequest<List<CourseReviewDto>>;
}
