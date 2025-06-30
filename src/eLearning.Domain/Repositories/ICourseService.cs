using eLearning.Domain.Dtos;

namespace eLearning.Domain.Repositories
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAllCoursesAsync();
        Task<CourseDto?> GetCourseByIdAsync(Guid courseId);
        Task CreateCourseAsync(CreateCourseDto dto);
        Task UpdateCourseAsync(Guid courseId, UpdateCourseDto dto);
        Task DeleteCourseAsync(Guid courseId);
        Task<double> CalculateCourseRatingAsync(Guid courseId);
        Task<int> GetReviewCountAsync(Guid courseId);
        Task<int> GetStudentEnrollmentCountAsync(Guid courseId);
        Task RecalculateCourseStatisticsAsync(Guid courseId);
        Task<List<CourseDto>> GetUserCoursesAsync(string userId);
        Task<List<CourseDto>> GetCoursesByIdsAsync(List<Guid> ids);
    }
}
