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
                Name = "Fitness & Exercises",
            });
            dbContext.SaveChanges();

            dbContext.ForumCategories.Add(new ForumCategory
            {
                Name = "Nutrition tips",
            });
            dbContext.SaveChanges();

            dbContext.ForumCategories.Add(new ForumCategory
            {
                Name = "Inspiration & Motivation",
            });
            dbContext.SaveChanges();

            dbContext.ForumCategories.Add(new ForumCategory
            {
                Name = "Supplements",
            });
            dbContext.SaveChanges();

            dbContext.ForumCategories.Add(new ForumCategory
            {
                Name = "My personal story",
            });
            dbContext.SaveChanges();

            await dbContext.SaveChangesAsync();
        }
    }
}
