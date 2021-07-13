namespace MyFitnessApp.Web.ViewModels.Exercises
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static MyFitnessApp.Common.DataConstants;

    public class AddExerciseInputModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int EquipmentId { get; set; } // Необходимо е, за да се подаде към страница, в която ще има списък с определени Equipments

        public string EquipmentName { get; set; }

        public int CategoryId { get; set; } // Необходимо е, за да се подаде към страница, в която ще има списък с определени Categories

        public string CategoryName { get; set; }

        public string DifficultyName { get; set; }

        public string ImageUrl { get; set; }

        public string VideoUrl { get; set; }

        // Dropdown Menu
        [Display(Name = "Day of week")]
        public DayOfWeek DayOfWeekName { get; set; }

        [Range(ExerciseWeightMinValue, ExerciseWeightMaxValue)]
        [Display(Name = "Exercise weight")]
        public double Weight { get; set; }

        [Range(ExerciseRepetitionsMinValue, ExerciseRepetitionsMaxValue)]
        [Display(Name = "Repetitions")]
        public int Repetitions { get; set; }

        [Range(ExerciseSetsMinValue, ExerciseSetsMaxValue)]
        [Display(Name = "Sets")]
        public int Sets { get; set; }
    }
}
