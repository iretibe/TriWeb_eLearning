using MediatR;

namespace eLearning.Application.Commands
{
    public record SendCourseRetirementNoticeCommand(Guid CourseId) : IRequest;
}
