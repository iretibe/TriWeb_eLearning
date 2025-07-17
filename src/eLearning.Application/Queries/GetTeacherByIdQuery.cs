using eLearning.Domain.Dtos;
using MediatR;

namespace eLearning.Application.Queries
{
    public record GetTeacherByIdQuery(string UserId) : IRequest<ApplicationUserDto?>;
}
