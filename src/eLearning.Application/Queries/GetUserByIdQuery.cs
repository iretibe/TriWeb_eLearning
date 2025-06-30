using eLearning.Domain.Dtos;
using MediatR;

namespace eLearning.Application.Queries
{
    public record GetUserByIdQuery(string UserId) : IRequest<ApplicationUserDto?>;
}
