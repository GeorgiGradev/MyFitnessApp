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
                    ImageUrl = "/images/seededArticleCategories/" + "fitness" + "." + "jpg",
                },
                new ArticleCategory
                {
                    Name = "Recipes",
                    ImageUrl = "/images/seededArticleCategories/" + "recipes" + "." + "jpg",
                },
                new ArticleCategory
                {
                    Name = "Nutrition",
                    ImageUrl = "/images/seededArticleCategories/" + "nutrition" + "." + "jpg",
                },
                new ArticleCategory
                {
                    Name = "Weightloss",
                    ImageUrl = "/images/seededArticleCategories/" + "weightloss" + "." + "jpg",
                },
                new ArticleCategory
                {
                    Name = "Inspiration",
                    ImageUrl = "/images/seededArticleCategories/" + "inspiration" + "." + "jpg",
                },
                new ArticleCategory
                {
                    Name = "Essentials",
                    ImageUrl = "/images/seededArticleCategories/" + "essentials" + "." + "jpg",
                },
            };

            foreach (var item in articleCategories)
            {
                await dbContext.ArticleCategories.AddAsync(new ArticleCategory
                {
                    Id = item.Id,
                    Name = item.Name,
                    ImageUrl = item.ImageUrl,
                });
            }
        }
    }
}
