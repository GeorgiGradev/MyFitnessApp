namespace MyFitnessApp.Data.Seeding
{
    using System;
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

            dbContext.ExerciseCategories.Add(new ExerciseCategory
            {
                Name = "Shoulders",
            });

            dbContext.SaveChanges();

            dbContext.ExerciseCategories.Add(new ExerciseCategory
            {
                Name = "Triceps",
            });

            dbContext.SaveChanges();

            dbContext.ExerciseCategories.Add(new ExerciseCategory
            {
                Name = "Biceps",
            });

            dbContext.SaveChanges();

            dbContext.ExerciseCategories.Add(new ExerciseCategory
            {
                Name = "Back",
            });

            dbContext.SaveChanges();

            dbContext.ExerciseCategories.Add(new ExerciseCategory
            {
                Name = "Chest",
            });

            dbContext.SaveChanges();

            dbContext.ExerciseCategories.Add(new ExerciseCategory
            {
                Name = "Forearm",
            });

            dbContext.SaveChanges();

            dbContext.ExerciseCategories.Add(new ExerciseCategory
            {
                Name = "Traps",
            });

            dbContext.SaveChanges();

            dbContext.ExerciseCategories.Add(new ExerciseCategory
            {
                Name = "Abs",
            });

            dbContext.SaveChanges();

            dbContext.ExerciseCategories.Add(new ExerciseCategory
            {
                Name = "Glutes",
            });

            dbContext.SaveChanges();

            dbContext.ExerciseCategories.Add(new ExerciseCategory
            {
                Name = "Quadriceps",
            });

            dbContext.SaveChanges();

            dbContext.ExerciseCategories.Add(new ExerciseCategory
            {
                Name = "Hamstrings",
            });

            dbContext.SaveChanges();

            dbContext.ExerciseCategories.Add(new ExerciseCategory
            {
                Name = "Calves",
            });

            dbContext.SaveChanges();

            await dbContext.SaveChangesAsync();
        }
    }
}
