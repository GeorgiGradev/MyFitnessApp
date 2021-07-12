namespace MyFitnessApp.Services.Data.Exercise
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Mapping;
    using MyFitnessApp.Web.ViewModels.Exercises;

    public class ExercisesService : IExercisesService
    {
        private readonly IDeletableEntityRepository<ExerciseCategory> exerciseCategoryRepository;
        private readonly IDeletableEntityRepository<ExerciseEquipment> exerciseEquipmentRepository;
        private readonly IDeletableEntityRepository<Exercise> exerciseRepository;

        public ExercisesService(
            IDeletableEntityRepository<ExerciseCategory> exerciseCategoryRepository,
            IDeletableEntityRepository<ExerciseEquipment> exerciseEquipmentRepository,
            IDeletableEntityRepository<Exercise> exerciseRepository)
        {
            this.exerciseCategoryRepository = exerciseCategoryRepository;
            this.exerciseEquipmentRepository = exerciseEquipmentRepository;
            this.exerciseRepository = exerciseRepository;
        }

        // Взима всички ExerciseCategories, за могат да се подадат в празната форма за Create New Exercise
        public IEnumerable<CategoryViewModel> GetExerciseCategories()
        {
            var viewModel = this.exerciseCategoryRepository
                .AllAsNoTracking()
                .Select(x => new CategoryViewModel
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
                .All()
                .Select(x => new EquipmentViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToList();

            return viewModel;
        }

        // Create new exercise ASYNC method
        public async Task CreateExcerciseAsync (CreateExerciseInputModel model, string userId)
        {
            var exercise = new Exercise()
            {
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                EquipmentId = model.EquipmentId,
                Difficulty = model.Difficulty,
                ImageUrl = model.ImageUrl,
                VideoUrl = model.VideoUrl,
                AddedByUserId = userId,
            };

            await this.exerciseRepository.AddAsync(exercise);
            await this.exerciseRepository.SaveChangesAsync();
        }

        // Взима всички Exercises от базата
        public IEnumerable<ExerciseViewModel> GetAllExercises(int pageNumber, int itemsPerPage = 12)
        {
            // 1-12 - page 1
            // 13-24 - page 2
            // 25-36 - page 3
            var viewModel = this.exerciseRepository
                .All()
                .OrderByDescending(x => x.Id) // последните добавени ще излизат най-отпред в списъка
                .Skip((pageNumber - 1) * itemsPerPage) // колко да пропуснем / Ако сме на първа страница = 0, ако сме на втора страница = 12...
                .Take(itemsPerPage)
                .To<ExerciseViewModel>()
                        // .Select(x => new ExerciseViewModel
                        // {
                        //    AddedByUserId = x.AddedByUserId,
                        //    Name = x.Name,
                        //    CategoryName = x.Category.Name,
                        //    ImageUrl = x.ImageUrl,
                        // })
                .ToList();

            return viewModel;
        }

        // Броят на Exercises ни е нужен за пейджирането, за да знаем коя е последната страница
        public int GetAllExercisesCount()
        {
            return this.exerciseRepository.All().Count();
        }
    }
}
