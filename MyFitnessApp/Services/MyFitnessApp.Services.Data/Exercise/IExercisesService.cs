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
        IEnumerable<ExerciseViewModel> GetAllExercises(int pageNumber, int itemsPerPage = 12); // нужни за пейджирането

        // Броят на Exercises ни е нужен за пейджирането, за да знаем коя е последната страница
        int GetAllExercisesCount();

        // // JUST FOR TESTING
        ExerciseViewModel GetTestExercise();
    }
}
