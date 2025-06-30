using eLearning.Application.Commands;
using eLearning.Domain.Repositories;
using MediatR;

namespace eLearning.Application.Handlers.Commands
{
    public class SendCourseRetirementNoticeCommandHandler : IRequestHandler<SendCourseRetirementNoticeCommand>
    {
        private readonly INotificationService _notificationService;

        public SendCourseRetirementNoticeCommandHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task Handle(SendCourseRetirementNoticeCommand request, CancellationToken cancellationToken)
        {
            await _notificationService.SendCourseRetirementNoticeAsync(request.CourseId);
        }
    }
}
