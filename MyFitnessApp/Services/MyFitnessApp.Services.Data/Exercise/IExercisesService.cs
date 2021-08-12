namespace MyFitnessApp.Services.Data.Exercise
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyFitnessApp.Web.ViewModels.Exercises;

    public interface IExercisesService
    {
        IEnumerable<CategoryViewModel> GetExerciseCategories();

        IEnumerable<EquipmentViewModel> GetExerciseEquipments();

        Task CreateExcerciseAsync(CreateExerciseInputModel model, string userId);

        IEnumerable<ExerciseViewModel> GetAllExercises(int pageNumber, int itemsPerPage); 

        int GetCounts();

        AddExerciseInputModel GetExerciseById(int id);

        Task AddExerciseToUserAsync(AddExerciseInputModel model, string userId);

        string GetEmbedYouTubeLink(string rawLink);

        IEnumerable<ExerciseViewModel> GetExercisesByCategoryId(int categoryId);

        IEnumerable<DiaryExeriseViewModel> GetExercisesByDayOfWeek(string userId, string dayOfWeek);

        Task RemoveExerciseAsync(string userId, int exerciseId);
    }
}
