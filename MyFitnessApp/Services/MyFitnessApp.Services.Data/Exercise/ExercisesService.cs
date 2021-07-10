namespace MyFitnessApp.Services.Data.Exercise
{
    using System.Collections.Generic;
    using System.Linq;

    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Web.ViewModels.Exercises;

    public class ExercisesService : IExercisesService
    {
        private readonly IDeletableEntityRepository<ExerciseCategory> exerciseCategoryRepository;

        public ExercisesService(IDeletableEntityRepository<ExerciseCategory> exerciseCategoryRepository)
        {
            this.exerciseCategoryRepository = exerciseCategoryRepository;
        }

        public IEnumerable<CategoryViewModel> GetExerciseCategories()
        {
            var viewModel = this.exerciseCategoryRepository
                .AllAsNoTracking().
                Select(x => new CategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToList();

            return viewModel;
        }
    }
}
