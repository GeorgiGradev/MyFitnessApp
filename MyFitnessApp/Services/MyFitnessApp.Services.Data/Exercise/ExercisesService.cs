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
        private readonly IDeletableEntityRepository<ExerciseEquipment> exerciseEquipmentRepository;

        public ExercisesService(
            IDeletableEntityRepository<ExerciseCategory> exerciseCategoryRepository,
            IDeletableEntityRepository<ExerciseEquipment> exerciseEquipmentRepository)
        {
            this.exerciseCategoryRepository = exerciseCategoryRepository;
            this.exerciseEquipmentRepository = exerciseEquipmentRepository;
        }

        // Взима всички ExerciseCategories, за могат да се подадат в празната форма за Create New Exercise
        public IEnumerable<CategoryViewModel> GetExerciseCategories()
        {
            var viewModel = this.exerciseCategoryRepository
                .All().
                Select(x => new CategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToList();

            return viewModel;
        }

        // Взима всички ExerciseEquipments, за могат да се подадат в празната форма за Create New Exercise
        public IEnumerable<EquipmentViewModel> GetExerciseEquipments()
        {
            var viewModel = this.exerciseEquipmentRepository
                .All().
                Select(x => new EquipmentViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToList();

            return viewModel;
        }
    }
}
