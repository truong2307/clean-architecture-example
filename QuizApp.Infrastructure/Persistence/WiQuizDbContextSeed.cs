using Microsoft.AspNetCore.Identity;
using QuizApp.Infrastructure.Identity;
using static QuizApp.Infrastructure.Common.Constants.Identity;

namespace QuizApp.Infrastructure.Persistence
{
    public static class WiQuizDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string[] roles = new string[] { Role.ADMIN, Role.USER, Role.TEACHER };

            foreach (string role in roles)
            {
                if (!roleManager.Roles.Any(c => role.Equals(c.Name)))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var administrator = new ApplicationUser { UserName = "testadmin", Email = "test@localhost" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Tt123`");
                await userManager.AddToRolesAsync(administrator, new[] { Role.ADMIN });
            }
        }
    }
}
