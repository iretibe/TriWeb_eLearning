using eLearning.Domain.Dtos;

namespace eLearning.Domain.Repositories
{
    public interface IEnrollmentService
    {
        Task EnrollLearnerAsync(string userId, Guid courseId);
        Task<IEnumerable<EnrollmentDto>> GetEnrollmentsByUserAsync(string userId);
        Task<bool> IsUserEnrolledAsync(string userId, Guid courseId);
    }
}
