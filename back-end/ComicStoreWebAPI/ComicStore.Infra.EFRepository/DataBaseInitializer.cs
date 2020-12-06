using ComicStore.Infra.EFRepository.Context;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ComicStore.Infra.EFRepository
{
    public class DataBaseInitializer
    {
        public static async Task CreateRoleIfNotExists(RoleManager<IdentityRole> roleManager, string roleName)
        {
            bool roleExists = await roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                var role = new IdentityRole
                {
                    Name = roleName
                };
                await roleManager.CreateAsync(role);
            }
        }

        private static async Task<IdentityResult> CreateUserIfNotExists(UserManager<IdentityUser> userManager, IdentityUser user, string password)
        {
            string adminPassword = password;
            IdentityResult result = await userManager.CreateAsync(user, adminPassword);
            return result;
        }
        public static async Task Init(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ComicStoreDbContext context = null)
        {
            await CreateRoleIfNotExists(roleManager, "Admin");
            await CreateRoleIfNotExists(roleManager, "User");

            var adminUser = new IdentityUser
            {
                UserName = "admin@comicstore.com",
                Email = "admin@comicstore.com",
                EmailConfirmed = true
            };

            var userResult = await CreateUserIfNotExists(userManager, adminUser, "@DMINc0m1cst0r34dm1n");
            if (userResult.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
