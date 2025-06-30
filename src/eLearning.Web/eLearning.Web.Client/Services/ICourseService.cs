using eLearning.Web.Client.Models;

namespace eLearning.Web.Client.Services
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
