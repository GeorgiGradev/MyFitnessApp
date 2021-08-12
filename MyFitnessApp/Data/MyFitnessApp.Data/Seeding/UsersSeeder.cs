namespace MyFitnessApp.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using MyFitnessApp.Common;
    using MyFitnessApp.Data.Models;

    internal class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Users.Any(x => x.UserName == "User"))
            {
                var user = new ApplicationUser
                {
                    AccessFailedCount = 0,
                    Email = "user@user.com",
                    NormalizedEmail = "USER@USER.COM",
                    TwoFactorEnabled = false,
                    EmailConfirmed = false,
                    IsDeleted = false,
                    CreatedOn = DateTime.UtcNow,
                    LockoutEnabled = false,
                    PhoneNumberConfirmed = true,
                    UserName = "user",
                    NormalizedUserName = "USER",
                    FirstName = "User",
                    LastName = "User",
                    PasswordHash = "AQAAAAEAACcQAAAAEGQ9IfdyJPYzY9lKPmwWrdN6T3AbPWBjEYxlLW7yfiOGd/4w/wqPv2Q+5O11ncA0gQ==", // Password = 123456
                };

                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Roles.Any())
            {
                return;
            }

            if (dbContext.Users.Any(u => u.Email == "admin@admin.com"))
            {
                return;
            }

            var admin = new ApplicationUser
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

            admin.Roles.Add(new IdentityUserRole<string>()
            {
                RoleId = dbContext.Roles
                    .FirstOrDefault(r => r.Name == GlobalConstants.AdministratorRoleName)?.Id,
            });

            await dbContext.Users.AddAsync(admin);
            await dbContext.SaveChangesAsync();
        }
    }
}
