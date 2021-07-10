namespace MyFitnessApp.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyFitnessApp.Data.Models;

    public class ExerciseCategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ExerciseCategories.Any())
            {
                return;
            }

            var exerciseCategoryNames = new List<string>
            {
                "Traps",
                "Shoulders",
                "Triceps",
                "Biceps",
                "Forearm",
                "Chest",
                "Back",
                "Abs",
                "Glutes",
                "Quadriceps",
                "Hamstrings",
                "Calves",
            };

            foreach (var item in exerciseCategoryNames)
            {
                await dbContext.ExerciseCategories.AddAsync(new ExerciseCategory
                {
                    Name = item,
                });
            }
        }
    }
}
