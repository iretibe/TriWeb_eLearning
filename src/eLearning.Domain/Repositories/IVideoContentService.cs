using eLearning.Domain.Dtos;

namespace eLearning.Domain.Repositories
{
    public interface IVideoContentService
    {
        Task AddVideoAsync(VideoContentDto dto);
        Task<List<VideoContentDto>> GetVideosByCourseAsync(Guid courseId);
        Task<List<VideoContentDto>> GetAllVideoCoursesAsync();
    }
}
