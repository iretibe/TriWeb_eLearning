using eLearning.UI.Client.Models;
using System.Net.Http.Json;

namespace eLearning.UI.Client.Services
{
    public class CourseClientService : ICourseService
    {
        private readonly HttpClient _http;
        private readonly string _backendUrl;

        public CourseClientService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _backendUrl = configuration["ApiUrls:BackendUrl"]
                ?? throw new InvalidOperationException("Backend URL is missing");
        }

        public async Task<bool> CreateCourseAsync(CourseModel course)
        {
            var response = await _http.PostAsJsonAsync($"{_backendUrl}/api/Courses/CreateCourse", course);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCourseAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"{_backendUrl}/api/Courses/DeleteCourse/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<List<CourseModel>> GetAllCoursesAsync()
        {
            var response = await _http.GetFromJsonAsync<List<CourseModel>>($"{_backendUrl}/api/Courses/GetAllCourses");

            return response ?? new List<CourseModel>();
        }

        public async Task<CourseModel?> GetCourseByIdAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<CourseModel>($"{_backendUrl}/api/Courses/GetCourseById/{id}");
        }

        public async Task<bool> UpdateCourseAsync(CourseModel course)
        {
            var response = await _http.PutAsJsonAsync($"{_backendUrl}/api/Courses/UpdateCourse/{course.Id}", course);

            return response.IsSuccessStatusCode;
        }
    }
}
