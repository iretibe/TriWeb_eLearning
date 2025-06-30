using eLearning.Domain.Dtos;
using MediatR;

namespace eLearning.Application.Commands
{
    public record CreateCourseReviewCommand(CreateCourseReviewDto ReviewDto) : IRequest;
}
