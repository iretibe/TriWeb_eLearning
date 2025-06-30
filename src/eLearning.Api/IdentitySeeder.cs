using eLearning.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace eLearning.Api
{
    public class IdentitySeeder
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public IdentitySeeder(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task SeedRolesAsync()
        {
            string[] roles = { "Lecturer", "Learner", "Admin" };

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new ApplicationRole { Name = role });
                }
            }
        }
    }
}
