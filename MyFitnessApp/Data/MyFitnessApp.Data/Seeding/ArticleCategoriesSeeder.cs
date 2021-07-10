//// Seeder на ArticleCategories ////

namespace MyFitnessApp.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyFitnessApp.Data.Models;

    public class ArticleCategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ArticleCategories.Any())
            {
                return;
            }

            var articleCategoryNames = new List<string>
            {
                "Recipes",
                "Nutrition",
                "Weight loss",
                "Fitness",
                "Inspiration",
            };

            foreach (var item in articleCategoryNames)
            {
                await dbContext.ArticleCategories.AddAsync(new ArticleCategory
                {
                    Name = item,
                });
            }
        }
    }
}
