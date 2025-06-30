using eLearning.Application.Commands;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Commands
{
    public class AddEnrollLearnerCommandHandler : IRequestHandler<AddEnrollLearnerCommand>
    {
        private readonly IEnrollmentService _service;

        public AddEnrollLearnerCommandHandler(IEnrollmentService service) => _service = service;

        public async Task Handle(AddEnrollLearnerCommand request, CancellationToken cancellationToken)
        {
            await _service.EnrollLearnerAsync(request.UserId, request.CourseId);
        }
    }
}
