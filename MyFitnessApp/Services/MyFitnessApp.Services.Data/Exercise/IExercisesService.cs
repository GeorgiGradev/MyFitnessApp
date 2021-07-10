namespace MyFitnessApp.Services.Data.Exercise
{
    using System.Collections.Generic;

    using MyFitnessApp.Web.ViewModels.Exercises;

    public interface IExercisesService
    {
        IEnumerable<CategoryViewModel> GetExerciseCategories();
    }
}
