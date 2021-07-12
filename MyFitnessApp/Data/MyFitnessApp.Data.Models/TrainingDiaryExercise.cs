namespace MyFitnessApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Common.Models;

    using static MyFitnessApp.Common.DataConstants;

    // Mapping table between Exercise & TraiingDiary
    public class TrainingDiaryExercise : BaseDeletableModel<int>
    {
        public int ExerciseId { get; set; }

        public Exercise Exercise { get; set; }

        public int TrainingDiaryId { get; set; }

        public TrainingDiary TrainingDiary { get; set; }

        [Range(ExerciseWeightMinValue, ExerciseWeightMaxValue)]
        public double Weight { get; set; }

        [Range(ExerciseRepetitionsMinValue, ExerciseRepetitionsMaxValue)]
        public int Repetitions { get; set; }

        [Range(ExerciseSetsMinValue, ExerciseSetsMaxValue)]
        public int Sets { get; set; }

        [Range(ExerciseDurationInMinutesMinValue, ExerciseDurationInMinutesMaxValue)]
        public TimeSpan DurationInMinutes { get; set; } // to be removed

        [Range(ExerciseCaloriesBurnedMinValue, ExerciseCaloriesBurnedMaxValue)]
        public double CaloriesBurned { get; set; } // to be removed
    }
}
