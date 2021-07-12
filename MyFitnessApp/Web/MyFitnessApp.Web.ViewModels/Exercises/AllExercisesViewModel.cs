namespace MyFitnessApp.Web.ViewModels.Exercises
{
    using System.Collections.Generic;

    public class AllExercisesViewModel
    {
        public IEnumerable<ExerciseViewModel> Exercises { get; set; }

        public int PageNumber { get; set; } // дава информация за номера на страницата, на която се намира 
    }
}
