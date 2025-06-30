using eLearning.WebApp.Client.Models;

namespace eLearning.WebApp.Client.Services
{
    public interface ICourseService
    {
        Task<List<CourseModel>> GetAllCoursesAsync();
        Task<CourseModel?> GetCourseByIdAsync(Guid id);
        Task<bool> CreateCourseAsync(CourseModel course);
        Task<bool> UpdateCourseAsync(CourseModel course);
        Task<bool> DeleteCourseAsync(Guid id);
        Task<List<CourseModel>> GetUserCoursesAsync(string userId);
        Task<List<CourseModel>> GetCoursesByIdsAsync(List<Guid> ids);
    }
}
