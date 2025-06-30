using eLearning.Domain.Dtos;
using MediatR;

namespace eLearning.Application.Queries
{
    public record GetUserEnrollmentsQuery(string UserId) : IRequest<List<EnrollmentDto>>;
}
