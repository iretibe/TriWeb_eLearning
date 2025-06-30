using MediatR;

namespace eLearning.Application.Commands
{
    public record DeleteCourseReviewCommand(Guid ReviewId) : IRequest;
}
