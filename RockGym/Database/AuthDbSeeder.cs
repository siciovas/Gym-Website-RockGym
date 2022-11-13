using Microsoft.AspNetCore.Identity;
using RockGym.Models.Auth;

namespace RockGym.Database
{
    public class AuthDbSeeder
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthDbSeeder(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            await AddDefaultRoles();
            await AddAdmin();
        }

        private async Task AddAdmin()
        {
            var newAdmin = new User
            {
                Email = "admin@gmail.com",
                UserName = "admin@gmail.com"
            };
            var exists = await _userManager.FindByNameAsync(newAdmin.UserName);
            if (exists == null)
            {
                var createOAdminResult = await _userManager.CreateAsync(newAdmin, "Rokas123?");
                if (createOAdminResult.Succeeded)
                {
                    await _userManager.AddToRolesAsync(newAdmin, Roles.All);
                }
            }
        }

        private async Task AddDefaultRoles()
        {
            foreach (var item in Roles.All)
            {
                var roleExists = await _roleManager.RoleExistsAsync(item);
                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new IdentityRole(item));
                }
            }
        }
    }
}
