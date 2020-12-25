using System;
using AMZEnterprisePortfolio.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace AMZEnterprisePortfolio.Data.EFCore
{
    /// <summary>
    /// Database initializer
    /// </summary>
    public static class ApplicationDbInitializer
    {
        private static ApplicationDbContext _context;
        public static void SeedData(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context
          )
        {
            _context = context;

            SeedRoles(roleManager);
            SeedUsers(userManager);
            SeedSettings();
        }

        /// <summary>
        /// Seed Users
        /// </summary>
        /// <param name="userManager">User manager instance</param>
        private static void SeedUsers(UserManager<User> userManager)
        {
            var adminCount = userManager.GetUsersInRoleAsync("Admin").Result.Count;

            if (adminCount <= 0)
            {
                if (userManager.FindByNameAsync
                        ("admin123").Result == null)
                {
                    User user = new User();
                    user.UserName = "admin123";
                    user.Email = "example@gmail.com";
                    user.EmailConfirmed = true;
                    IdentityResult result = userManager.CreateAsync
                        (user, "p@sS123").Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "admin").Wait();
                    }
                }
            }

        }

        /// <summary>
        /// Seed Users Roles
        /// </summary>
        /// <param name="roleManager">Role manager instance</param>
        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }

        /// <summary>
        /// Seed Settings
        /// </summary>
        private static void SeedSettings()
        {
            if (!_context.Settings.Any())
            {
                //Insert default empty settings
                _context.Settings.Add(new Setting()
                {
                    CvFilePathGuid = Guid.NewGuid()
                });

                _context.SaveChanges();
            }
        }
    }
}