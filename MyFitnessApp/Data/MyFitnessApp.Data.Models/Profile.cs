namespace MyFitnessApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using MyFitnessApp.Data.Common.Models;

    using static MyFitnessApp.Common.DataConstants;

    public class Profile : BaseDeletableModel<int>
    {
        public Gender Gender { get; set; }

        public ActivityLevel ActivityLevel { get; set; }

        public string ImageUrl { get; set; }

        [Range(ProfileWeightInKgMinValue, ProfileWeightInKgMaxValue)]
        public double CurrentWeightInKg { get; set; }

        [Range(ProfileWeightInKgMinValue, ProfileWeightInKgMaxValue)]
        public double GoalWeightInKg { get; set; }

        [Range(ProfileBodyMeasurementMinValue, ProfileBodyMeasurementMaxValue)]
        public double HeightInCm { get; set; }

        [Range(ProfileBodyMeasurementMinValue, ProfileBodyMeasurementMaxValue)]
        public double NeckInCm { get; set; }

        [Range(ProfileBodyMeasurementMinValue, ProfileBodyMeasurementMaxValue)]
        public double WaistInCm { get; set; }

        [Range(ProfileBodyMeasurementMinValue, ProfileBodyMeasurementMaxValue)]
        public double HipsInCm { get; set; }

        [Range(ProfileDailyIntakeGoalMinValue, ProfileDailyIntakeGoalMaxValue)]
        public double DailyProteinIntakeGoal { get; set; }

        [Range(ProfileDailyIntakeGoalMinValue, ProfileDailyIntakeGoalMaxValue)]
        public double DailyCarbohydratesIntakeGoal { get; set; }

        [Range(ProfileDailyIntakeGoalMinValue, ProfileDailyIntakeGoalMaxValue)]
        public double DailyFatIntakeGoal { get; set; }

        [MaxLength(AboutMeMaxLength)]
        public string AboutMe { get; set; }

        [MaxLength(WhyGetInShapeMaxLength)]
        public string WhyGetInShape { get; set; }

        [MaxLength(MyInspirationsMaxLength)]
        public string MyInspirations { get; set; }

        public double CalculatedDailyCaloriesIntakeGoal => (this.DailyProteinIntakeGoal * 4) + (this.DailyCarbohydratesIntakeGoal * 4) + (this.DailyFatIntakeGoal * 9);

        [Required]
        [ForeignKey(nameof(AddedByUser))]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}
