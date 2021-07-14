//// Seeder на ExerciseCategories ////

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

            var exerciseCategories = new List<ExerciseCategory>
             {
                 new ExerciseCategory
                 {
                     Name = "Chest",
                 },
                 new ExerciseCategory
                 {
                     Name = "Back",
                 },

                 new ExerciseCategory
                 {
                     Name = "Biceps",
                 },
                 new ExerciseCategory
                 {
                     Name = "Triceps",
                 },
                 new ExerciseCategory
                 {
                     Name = "Shoulders",
                 },
                 new ExerciseCategory
                 {
                     Name = "Forearm",
                 },
                 new ExerciseCategory
                 {
                     Name = "Traps",
                 },
                 new ExerciseCategory
                 {
                     Name = "Abs",
                 },
                 new ExerciseCategory
                 {
                     Name = "Glutes",
                 },
                 new ExerciseCategory
                 {
                     Name = "Quadriceps",
                 },
                 new ExerciseCategory
                 {
                     Name = "Hamstrings",
                 },
                 new ExerciseCategory
                 {
                     Name = "Calves",
                 },
             };

            foreach (var item in exerciseCategories)
            {
                await dbContext.ExerciseCategories.AddAsync(new ExerciseCategory
                {
                    Id = item.Id,
                    Name = item.Name,
                });
            }
        }
    }
}
