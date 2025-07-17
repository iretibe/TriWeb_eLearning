using eLearning.WebApp.Client.Models;
using System.Net.Http.Json;

namespace eLearning.WebApp.Client.Services
{
    public class UserClientService : IUserService
    {
        private readonly HttpClient _http;
        private readonly string _backendUrl;

        public UserClientService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _backendUrl = configuration["ApiUrls:BackendUrl"]
                ?? throw new InvalidOperationException("Backend URL is missing");
        }

        public async Task<string> GetUserIdByEmailAsync(string email)
        {
            var response = await _http.GetFromJsonAsync<UserIdModel>($"{_backendUrl}/api/Users/GetUserIdByEmail?email={email}");
            return response?.UserId ?? string.Empty;
        }
    }
}
