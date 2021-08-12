namespace MyFitnessApp.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using MyFitnessApp.Data.Models;

    public class IndexViewModel
    {
        public IEnumerable<Exercise> Exercises { get; set; }

        public IEnumerable<ExerciseCategory> ExerciseCategories { get; set; }

        public IEnumerable<Food> Foods { get; set; }

        public IEnumerable<ExerciseEquipment> ExerciseEquipments { get; set; }

        public int UsersCount { get; set; }
    }
}
