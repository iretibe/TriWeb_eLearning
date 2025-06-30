using eLearning.Domain.Dtos;
using MediatR;

namespace eLearning.Application.Queries
{
    public record GetCourseReviewByIdQuery(Guid ReviewId) : IRequest<CourseReviewDto?>;
}
