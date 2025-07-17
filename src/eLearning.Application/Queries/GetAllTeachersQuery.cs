using eLearning.Domain.Dtos;
using MediatR;

namespace eLearning.Application.Queries
{
    public record GetAllTeachersQuery : IRequest<List<ApplicationUserDto>>;
}
