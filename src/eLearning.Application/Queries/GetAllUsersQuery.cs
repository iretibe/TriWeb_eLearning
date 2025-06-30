using eLearning.Domain.Dtos;
using MediatR;

namespace eLearning.Application.Queries
{
    public record GetAllUsersQuery : IRequest<List<ApplicationUserDto>>;
}
