namespace MyFitnessApp.Services.Data.Exercise
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyFitnessApp.Web.ViewModels.Exercises;

    public interface IExercisesService
    {
        // Взима всички ExerciseCategories, за да се подадат на празното View при отвяряне на Create New Exercise
        IEnumerable<CategoryViewModel> GetExerciseCategories();

        // Взима всички ExerciseEqiupments, за да се подадат на празното View при отвяряне на Create New Exercise
        IEnumerable<EquipmentViewModel> GetExerciseEquipments();

        // Създаване на Exercise с ASYNC Method
        Task CreateExcerciseAsync(CreateExerciseInputModel model, string userId);

        // Взима всички Exercises от базата
        IEnumerable<SingleExerciseViewModel> GetAllExercises(int pageNumber, int itemsPerPage = 12); // нужни за пейджирането

        // Броят на Exercises ни е нужен за пейджирането, за да знаем коя е последната страница
        int GetAllExercisesCount();

        // Взима даден Exercise по Id
        AddExerciseInputModel GetExerciseById(int id);

        // Добавя упражнение към потребител, като получава модел, от който си взима данните + usedId
        Task AddExerciseToUserAsync(AddExerciseInputModel model, string userId);

        // Get EMBED youtube link
        string GetEmbedYouTubeLink(string rawLink);

        // Get exercises by CategoryId
        IEnumerable<SingleExerciseViewModel> GetExercisesByCategoryId(int categoryId);

        // Взима всички упражнения, които потребителят е добавил
        IEnumerable<SingleExerciseViewModel> GetAllExercisesByUserId(string userId);

        // Взима упражнения по ден от седмицата + UserID
        IEnumerable<DiaryExeriseViewModel> GetExercisesByDayOfWeek(string userId, string dayOfWeek);

        // Премахва упражнението от Excercise Diary на User-a
        Task RemoveExerciseAsync(string userId, int exerciseId);
    }
}
