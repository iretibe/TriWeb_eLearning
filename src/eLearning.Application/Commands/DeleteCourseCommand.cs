using MediatR;

namespace eLearning.Application.Commands
{
    public record DeleteCourseCommand(Guid Id) : IRequest;
}
