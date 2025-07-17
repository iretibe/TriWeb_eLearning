using eLearning.UI.Client.Models;

namespace eLearning.UI.Client.Services
{
    public interface ICourseService
    {
        Task<List<CourseModel>> GetAllCoursesAsync();
        Task<CourseModel?> GetCourseByIdAsync(Guid id);
        Task<bool> CreateCourseAsync(CourseModel course);
        Task<bool> UpdateCourseAsync(CourseModel course);
        Task<bool> DeleteCourseAsync(Guid id);
    }
}
