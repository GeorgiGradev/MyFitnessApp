namespace MyFitnessApp.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MyFitnessApp.Data.Models;

    public class ForumCategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ForumCategories.Any())
            {
                return;
            }

            dbContext.ForumCategories.Add(new ForumCategory
            {
                Name = "Supplements",
                Description = "Supplement info, feedback and reviews!",
            });
            dbContext.SaveChanges();

            dbContext.ForumCategories.Add(new ForumCategory
            {
                Name = "Bodyfit",
                Description = "Are you BodyFit subscriber or interested in learning more about it?",
            });
            dbContext.SaveChanges();

            dbContext.ForumCategories.Add(new ForumCategory
            {
                Name = "Workout Equipment",
                Description = "All about equipment and iron!",
            });
            dbContext.SaveChanges();

            dbContext.ForumCategories.Add(new ForumCategory
            {
                Name = "Workout Programs",
                Description = "What workout is best for your goal?",
            });
            dbContext.SaveChanges();

            dbContext.ForumCategories.Add(new ForumCategory
            {
                Name = "Exercises",
                Description = "Post questions about specific exercises here.",
            });
            dbContext.SaveChanges();

            dbContext.ForumCategories.Add(new ForumCategory
            {
                Name = "Nutrition",
                Description = "Everything related to proper nutrition.",
            });
            dbContext.SaveChanges();

            dbContext.ForumCategories.Add(new ForumCategory
            {
                Name = "Loosing Fat",
                Description = "Get tips for reaching your fat loss goals!",
            });
            dbContext.SaveChanges();

            dbContext.ForumCategories.Add(new ForumCategory
            {
                Name = "Teen Bodybuilding",
                Description = "Teenagers discuss your issues here!",
            });
            dbContext.SaveChanges();

            dbContext.ForumCategories.Add(new ForumCategory
            {
                Name = "Female Bodybuilding",
                Description = "Discuss training, nutrition, competing and getting in shape. Introduce yourself!",
            });
            dbContext.SaveChanges();

            dbContext.ForumCategories.Add(new ForumCategory
            {
                Name = "Powerlifting/Strongman",
                Description = "Strongest people in the world.",
            });
            dbContext.SaveChanges();

            dbContext.ForumCategories.Add(new ForumCategory
            {
                Name = "Personal Trainers Section",
                Description = "Compare notes with other trainers and improve your client's results!",
            });
            dbContext.SaveChanges();

            dbContext.ForumCategories.Add(new ForumCategory
            {
                Name = "Post Your Own Articles!",
                Description = "Here you can write an original, detailed article on any fitness subject and share it with the world!",
            });
            dbContext.SaveChanges();

            await dbContext.SaveChangesAsync();
        }
    }
}
