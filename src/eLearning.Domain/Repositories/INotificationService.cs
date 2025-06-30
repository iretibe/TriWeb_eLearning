using eLearning.Domain.Dtos;

namespace eLearning.Domain.Repositories
{
    public interface INotificationService
    {
        Task SendCourseRetirementNoticeAsync(Guid courseId);
        Task<IEnumerable<NotificationDto>> GetNotificationsForUserAsync(string userId);
    }
}
