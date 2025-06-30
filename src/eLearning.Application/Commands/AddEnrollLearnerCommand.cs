using MediatR;

namespace eLearning.Application.Commands
{
    public record AddEnrollLearnerCommand(string UserId, Guid CourseId) : IRequest;
}
