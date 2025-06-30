
using eLearning.WebApp.Client.Models;
using System.Net.Http.Json;

namespace eLearning.WebApp.Client.Services
{
    public class UserClientService : IUserService
    {
        private readonly HttpClient _http;

        public UserClientService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
        }

        public async Task<string> GetUserIdByEmailAsync(string email)
        {
            var response = await _http.GetFromJsonAsync<UserIdModel>($"https://localhost:7012/api/Users/GetUserIdByEmail?email={email}");
            return response?.UserId ?? string.Empty;
        }
    }
}
