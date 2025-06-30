using Microsoft.AspNetCore.Identity;

namespace eLearning.Domain.Entities
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public ApplicationUser User { get; set; } = default!;
        public ApplicationRole Role { get; set; } = default!;
    }
}
