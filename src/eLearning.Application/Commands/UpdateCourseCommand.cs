using eLearning.Domain.Dtos;
using MediatR;

namespace eLearning.Application.Commands
{
    public record UpdateCourseCommand(Guid Id, UpdateCourseDto Dto) : IRequest;
}
