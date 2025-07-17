using eLearning.Domain.Dtos;
using eLearning.Domain.Entities;
using eLearning.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eLearning.Infrastructure.Repositories
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task AssignRoleAsync(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            
            if (user != null && !await _userManager.IsInRoleAsync(user, role))
            {
                await _userManager.AddToRoleAsync(user, role);
            }
        }

        public async Task<IEnumerable<ApplicationUserDto>> GetAllLecturersAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            var result = new List<ApplicationUserDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Contains("Lecturer"))
                {
                    result.Add(new ApplicationUserDto
                    {
                        Id = user.Id,
                        UserName = user.UserName!,
                        Email = user.Email!,
                        Roles = roles
                    });
                }
            }

            return result;
        }

        //public async Task<IEnumerable<ApplicationUserDto>> GetAllUsersAsync()
        //{
        //    var users = await _userManager.Users.ToListAsync();

        //    var result = await Task.WhenAll(users.Select(async user => new ApplicationUserDto
        //    {
        //        Id = user.Id,
        //        UserName = user.UserName!,
        //        Email = user.Email!,
        //        Roles = await _userManager.GetRolesAsync(user)
        //    }));

        //    return result;
        //}

        public async Task<IEnumerable<ApplicationUserDto>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            var result = new List<ApplicationUserDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Contains("Learner"))
                {
                    result.Add(new ApplicationUserDto
                    {
                        Id = user.Id,
                        UserName = user.UserName!,
                        Email = user.Email!,
                        Roles = roles
                    });
                }
            }

            return result;
        }

        public async Task<ApplicationUserDto?> GetLecturerByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return null;

            var roles = await _userManager.GetRolesAsync(user);

            if (!roles.Contains("Lecturer"))
                return null;

            return new ApplicationUserDto
            {
                Id = user.Id,
                UserName = user.UserName!,
                Email = user.Email!,
                Roles = roles
            };
        }

        //public async Task<ApplicationUserDto?> GetUserByIdAsync(string userId)
        //{
        //    var user = await _userManager.FindByIdAsync(userId);

        //    if (user is null) return null;

        //    var roles = await _userManager.GetRolesAsync(user);

        //    return new ApplicationUserDto
        //    {
        //        Id = user.Id,
        //        UserName = user.UserName!,
        //        Email = user.Email!,
        //        Roles = roles
        //    };
        //}

        public async Task<ApplicationUserDto?> GetUserByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return null;

            var roles = await _userManager.GetRolesAsync(user);

            if (!roles.Contains("Learner"))
                return null;

            return new ApplicationUserDto
            {
                Id = user.Id,
                UserName = user.UserName!,
                Email = user.Email!,
                Roles = roles
            };
        }

        //public async Task<IEnumerable<ApplicationUserDto>> GetAllLearnerUsersAsync()
        //{
        //    var learnerRole = await _context.Roles
        //        .FirstOrDefaultAsync(r => r.NormalizedName == "LEARNER");

        //    if (learnerRole == null)
        //        return Enumerable.Empty<ApplicationUserDto>();

        //    var learnerUsers = from user in _context.Users
        //                       join userRole in _context.UserRoles on user.Id equals userRole.UserId
        //                       where userRole.RoleId == learnerRole.Id
        //                       select user;

        //    var users = await learnerUsers.ToListAsync();

        //    var result = await Task.WhenAll(users.Select(async user => new ApplicationUserDto
        //    {
        //        Id = user.Id,
        //        UserName = user.UserName!,
        //        Email = user.Email!,
        //        Roles = await _userManager.GetRolesAsync(user)
        //    }));

        //    return result;
        //}

        public async Task<string> GetUserIdByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user?.Id ?? string.Empty;
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return user is null ? Enumerable.Empty<string>() : await _userManager.GetRolesAsync(user);
        }
    }
}
