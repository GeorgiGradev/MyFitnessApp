namespace MyFitnessApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Common.Models;

    using static MyFitnessApp.Common.DataConstants;

    // Mapping table between Exercise & ExerciseDiary
    public class UserExercise : BaseDeletableModel<int>
    {
        public int ExerciseId { get; set; }

        public Exercise Exercise { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        // Dropdown Menu
        public WeekDay WeekDay { get; set; }

        [Range(ExerciseWeightMinValue, ExerciseWeightMaxValue)]
        public double Weight { get; set; }

        [Range(ExerciseRepetitionsMinValue, ExerciseRepetitionsMaxValue)]
        public int Repetitions { get; set; }

        [Range(ExerciseSetsMinValue, ExerciseSetsMaxValue)]
        public int Sets { get; set; }
    }
}
