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

            var articleCategories = new List<ArticleCategory>
            {
                new ArticleCategory
                {
                    Name = "Fitness",
                },
                new ArticleCategory
                {
                    Name = "Recipes",
                },
                new ArticleCategory
                {
                    Name = "Nutrition",
                },
                new ArticleCategory
                {
                    Name = "Weight loss",
                },
                new ArticleCategory
                {
                    Name = "Inspiration",
                },
            };

            foreach (var item in articleCategories)
            {
                await dbContext.ArticleCategories.AddAsync(new ArticleCategory
                {
                    Id = item.Id,
                    Name = item.Name,
                });
            }
        }
    }
}
