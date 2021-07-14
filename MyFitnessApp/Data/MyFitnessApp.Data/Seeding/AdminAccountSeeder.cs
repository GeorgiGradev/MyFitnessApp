namespace MyFitnessApp.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using MyFitnessApp.Common;
    using MyFitnessApp.Data.Models;

    internal class AdminAccountSeeder : ISeeder
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AdminAccountSeeder(
            UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public AdminAccountSeeder()
        {
        }

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Roles.Any())
            {
                return;
            }

            if (dbContext.Users.Any(u => u.Email == "admin@admin.com"))
            {
                return;
            }

            var user = new ApplicationUser
            {
                AccessFailedCount = 0,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                TwoFactorEnabled = false,
                EmailConfirmed = false,
                IsDeleted = false,
                CreatedOn = DateTime.UtcNow,
                LockoutEnabled = false,
                PhoneNumberConfirmed = true,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                FirstName = "Admin",
                LastName = "Admin",
                PasswordHash = "AQAAAAEAACcQAAAAEGQ9IfdyJPYzY9lKPmwWrdN6T3AbPWBjEYxlLW7yfiOGd/4w/wqPv2Q+5O11ncA0gQ==", // Password = 123456
            };

            user.Roles.Add(new IdentityUserRole<string>()
            {
                RoleId = dbContext.Roles
                    .FirstOrDefault(r => r.Name == GlobalConstants.AdministratorRoleName)?.Id,
            });

            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }
    }
}