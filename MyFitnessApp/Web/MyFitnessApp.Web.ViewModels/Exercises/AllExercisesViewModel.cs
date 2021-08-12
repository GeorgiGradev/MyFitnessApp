namespace MyFitnessApp.Web.ViewModels.Exercises
{
    using System.Collections.Generic;

    public class AllExercisesViewModel : PagingViewModel
    {
        public IEnumerable<ExerciseViewModel> Exercises { get; set; }
    }
}
