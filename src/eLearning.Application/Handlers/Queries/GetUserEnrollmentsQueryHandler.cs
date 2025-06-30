using eLearning.Application.Queries;
using eLearning.Domain.Dtos;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Queries
{
    public class GetUserEnrollmentsQueryHandler : IRequestHandler<GetUserEnrollmentsQuery, List<EnrollmentDto>>
    {
        private readonly IEnrollmentService _service;

        public GetUserEnrollmentsQueryHandler(IEnrollmentService service) => _service = service;

        public async Task<List<EnrollmentDto>> Handle(GetUserEnrollmentsQuery request, CancellationToken cancellationToken)
        {
            return (await _service.GetEnrollmentsByUserAsync(request.UserId)).ToList();
        }
    }
}
