namespace MyFitnessApp.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MyFitnessApp.Data.Models;

    public class ProfileSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Profiles.Any())
            {
                return;
            }

            var admin = dbContext.Users.
              Where(x => x.UserName == "admin")
              .FirstOrDefault();
            var adminProfile = new Profile
            {
                Gender = Gender.Female,
                ActivityLevel = ActivityLevel.Moderate,
                CurrentWeightInKg = 55,
                GoalWeightInKg = 50,
                HeightInCm = 170,
                NeckInCm = 34,
                WaistInCm = 60,
                HipsInCm = 90,
                DailyProteinIntakeGoal = 150,
                DailyCarbohydratesIntakeGoal = 150,
                DailyFatIntakeGoal = 40,
                AddedByUser = admin,
                ImageUrl = "/images/profileimages/" + "1" + "." + "jpg",
                AboutMe = "I am the admin",
                MyInspirations = "To be healhty",
                WhyGetInShape = "To be the best looking girl",
            };
            await dbContext.Profiles.AddAsync(adminProfile);
            await dbContext.SaveChangesAsync();
            admin.ProfileId = adminProfile.Id;

            var user = dbContext.Users.
              Where(x => x.UserName == "user")
              .FirstOrDefault();
            var usersProfile = new Profile
            {
                Gender = Gender.Male,
                ActivityLevel = ActivityLevel.Active,
                CurrentWeightInKg = 85,
                GoalWeightInKg = 90,
                HeightInCm = 180,
                NeckInCm = 45,
                WaistInCm = 70,
                HipsInCm = 100,
                DailyProteinIntakeGoal = 250,
                DailyCarbohydratesIntakeGoal = 250,
                DailyFatIntakeGoal = 60,
                AddedByUser = user,
                ImageUrl = "/images/profileimages/" + "2" + "." + "jpg",
                AboutMe = "I am a user",
                MyInspirations = "To be strong",
                WhyGetInShape = "To be the best looking boy",
            };
            await dbContext.Profiles.AddAsync(usersProfile);
            await dbContext.SaveChangesAsync();
            user.ProfileId = usersProfile.Id;
        }
    }
}
