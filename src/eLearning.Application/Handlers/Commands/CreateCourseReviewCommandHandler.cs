using eLearning.Application.Commands;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Commands
{
    public class CreateCourseReviewCommandHandler : IRequestHandler<CreateCourseReviewCommand>
    {
        private readonly ICourseReviewService _service;

        public CreateCourseReviewCommandHandler(ICourseReviewService service) => _service = service;

        public async Task Handle(CreateCourseReviewCommand request, CancellationToken cancellationToken)
        {
            await _service.AddReviewAsync(request.ReviewDto);
        }
    }
}
