using eLearning.Domain.Dtos;

namespace eLearning.Domain.Repositories
{
    public interface ICourseReviewService
    {
        Task<IEnumerable<CourseReviewDto>> GetReviewsByCourseAsync(Guid courseId);
        Task<CourseReviewDto?> GetReviewByIdAsync(Guid reviewId);
        Task AddReviewAsync(CreateCourseReviewDto dto);
        Task DeleteReviewAsync(Guid reviewId);
        Task<double> GetAverageRatingAsync(Guid courseId);
        Task<int> GetTotalReviewCountAsync(Guid courseId);
    }
}
