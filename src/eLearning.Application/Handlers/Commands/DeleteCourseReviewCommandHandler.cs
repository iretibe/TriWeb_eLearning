using eLearning.Application.Commands;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Commands
{
    public class DeleteCourseReviewCommandHandler : IRequestHandler<DeleteCourseReviewCommand>
    {
        private readonly ICourseReviewService _service;

        public DeleteCourseReviewCommandHandler(ICourseReviewService service) => _service = service;

        public async Task Handle(DeleteCourseReviewCommand request, CancellationToken cancellationToken)
        {
            await _service.DeleteReviewAsync(request.ReviewId);
        }
    }
}
