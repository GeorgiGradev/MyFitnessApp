namespace MyFitnessApp.Web.ViewModels.Exercises
{
    using System.Collections.Generic;

    public class AllExercisesViewModel : PagingViewModel // Наследява PagingViewModel-a, в който са всички необходими параметри за Paging
    {
        public IEnumerable<SingleExerciseViewModel> Exercises { get; set; }
    }
}
