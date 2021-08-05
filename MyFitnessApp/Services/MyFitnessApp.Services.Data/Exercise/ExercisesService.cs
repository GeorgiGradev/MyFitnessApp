namespace MyFitnessApp.Services.Data.Exercise
{
    using System;
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
        private readonly IDeletableEntityRepository<UserExercise> userExerciseRepository;

        public ExercisesService(
            IDeletableEntityRepository<ExerciseCategory> exerciseCategoryRepository,
            IDeletableEntityRepository<ExerciseEquipment> exerciseEquipmentRepository,
            IDeletableEntityRepository<Exercise> exerciseRepository,
            IDeletableEntityRepository<UserExercise> userExerciseRepository)
        {
            this.exerciseCategoryRepository = exerciseCategoryRepository;
            this.exerciseEquipmentRepository = exerciseEquipmentRepository;
            this.exerciseRepository = exerciseRepository;
            this.userExerciseRepository = userExerciseRepository;
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
        public async Task CreateExcerciseAsync(CreateExerciseInputModel model, string userId)
        {
            var exercise = new Exercise()
            {
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                EquipmentId = model.EquipmentId,
                Difficulty = model.Difficulty,
                ImageUrl = model.ImageUrl,
                VideoUrl = this.GetEmbedYouTubeLink(model.VideoUrl),
                AddedByUserId = userId,
            };

            await this.exerciseRepository.AddAsync(exercise);
            await this.exerciseRepository.SaveChangesAsync();
        }

        // Взима всички Exercises от базата
        public IEnumerable<SingleExerciseViewModel> GetAllExercises(int pageNumber, int itemsPerPage)
        {
            // 1-12 - page 1
            // 13-24 - page 2
            // 25-36 - page 3
            var viewModel = this.exerciseRepository
                .All()
                .OrderByDescending(x => x.Id) // последните добавени ще излизат най-отпред в списъка
                .Skip((pageNumber - 1) * itemsPerPage) // колко да пропуснем / Ако сме на първа страница = 0, ако сме на втора страница = 12...
                .Take(itemsPerPage)
                .To<SingleExerciseViewModel>()
                .ToList();

            // .Select(x => new ExerciseViewModel
            // {
            //    AddedByUserId = x.AddedByUserId,
            //    Name = x.Name,
            //    CategoryName = x.Category.Name,
            //    ImageUrl = x.ImageUrl,
            // })
            // .ToList();
            return viewModel;
        }

        // Броят на Exercises ни е нужен за пейджирането, за да знаем коя е последната страница
        public int GetAllExercisesCount()
        {
            return this.exerciseRepository.All().Count();
        }

        public AddExerciseInputModel GetExerciseById(int id)
        {
            var viewModel = this.exerciseRepository
                .All()
                .Where(x => x.Id == id)
                .Select(x => new AddExerciseInputModel
                {
                    Name = x.Name,
                    Description = x.Description,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name,
                    ImageUrl = x.ImageUrl,
                    VideoUrl = x.VideoUrl,
                    EquipmentId = x.EquipmentId,
                    EquipmentName = x.Equipment.Name,
                    DifficultyName = x.Difficulty.ToString(),
                })
                .FirstOrDefault();

            return viewModel;
        }

        public async Task AddExerciseToUserAsync(AddExerciseInputModel model, string userId)
        {
            var userExercise = new UserExercise
            {
                ExerciseId = model.Id,
                UserId = userId,
                Repetitions = model.Repetitions,
                Sets = model.Sets,
                Weight = model.Weight,
                WeekDay = model.WeekDay,
            };

            bool doesExerciseExistInDiary = this.userExerciseRepository
                .All()
                .Any(x => x.ExerciseId == userExercise.ExerciseId
                        && x.WeekDay == userExercise.WeekDay
                        && x.UserId == userId);

            if (!doesExerciseExistInDiary)
            {
                await this.userExerciseRepository.AddAsync(userExercise);
                await this.userExerciseRepository.SaveChangesAsync();
            }

            // премахва и добавя наново упражнението = EDIT
            else
            {
                var exerciseToRemove = this.userExerciseRepository
                    .All()
                    .Where(x => x.ExerciseId == userExercise.ExerciseId
                        && x.WeekDay == userExercise.WeekDay
                        && x.UserId == userId)
                    .FirstOrDefault();
                this.userExerciseRepository.Delete(exerciseToRemove);

                await this.userExerciseRepository.AddAsync(userExercise);
                await this.userExerciseRepository.SaveChangesAsync();
            }
        }

        public string GetEmbedYouTubeLink(string rawLink)
        {
            var result = string.Empty;
            if (rawLink.Contains("watch"))
            {
                var source1 = rawLink.Split("watch")[0];
                var source2 = rawLink.Split("=")[1];
                var source3 = source2.Split("&")[0];
                result = source1 + "embed/" + source3;
            }
            else if (rawLink.Contains("youtu.be"))
            {
                var source1 = rawLink.Split("youtu.be/")[0];
                var source2 = rawLink.Split("youtu.be/")[1];
                result = source1 + "www.youtube.com/embed/" + source2;
            }

            return result;
        }

        public IEnumerable<SingleExerciseViewModel> GetExercisesByCategoryId(int categoryId)
        {
            var viewModel = this.exerciseRepository
                .All()
                .Where(x => x.CategoryId == categoryId)
                .OrderByDescending(x => x.Id) // последните добавени ще излизат най-отпред в списъка
                .To<SingleExerciseViewModel>()
                .ToList();

            return viewModel;
        }

        public IEnumerable<DiaryExeriseViewModel> GetExercisesByDayOfWeek(string userId, string dayOfWeek)
        {
            var viewModel = this.userExerciseRepository
                .All()
                .Where(x => x.UserId == userId && x.WeekDay == Enum.Parse<WeekDay>(dayOfWeek))
                .Select(x => new DiaryExeriseViewModel
                {
                    Id = x.Id,
                    Name = x.Exercise.Name,
                    ImageUrl = x.Exercise.ImageUrl,
                    DayOfWeek = dayOfWeek,
                    Repetitions = x.Repetitions,
                    Sets = x.Sets,
                    Category = x.Exercise.Category.Name,
                    Weight = x.Weight,
                    ExerciseId = x.ExerciseId,
                })
                .ToList();

            return viewModel;
        }

        public async Task RemoveExerciseAsync(string userId, int exerciseId)
        {
            var exercise = this.userExerciseRepository
                .All()
                .Where(x => x.UserId == userId && x.ExerciseId == exerciseId)
                .FirstOrDefault();

            this.userExerciseRepository.Delete(exercise);
            await this.userExerciseRepository.SaveChangesAsync();
        }

        public int GetCounts()
        {
            var totalExercisesCount = this.exerciseRepository
                .All()
                .Count();

            return totalExercisesCount;
        }
    }
}
