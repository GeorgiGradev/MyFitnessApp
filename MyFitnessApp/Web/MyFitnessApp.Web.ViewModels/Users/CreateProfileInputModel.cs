namespace MyFitnessApp.Web.ViewModels.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using MyFitnessApp.Data.Models;

    using static MyFitnessApp.Common.DataConstants;

    public class CreateProfileInputModel
    {
        // [Required(ErrorMessage = "The field is required")]
        // public DateTime BirthDate { get; set; }

        [Display(Name = "Choose gender")]
        public Gender Gender { get; set; }

        [Display(Name = "Choose activity level")]
        public ActivityLevel ActivityLevel { get; set; }

        [Display(Name = "Image (.jpg format only)")]
        public IFormFile ImageUrl { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Range(ProfileWeightInKgMinValue, ProfileWeightInKgMaxValue, ErrorMessage = "The value must be between {1} and {2}")]
        [Display(Name = "Current weight in kg")]
        public double CurrentWeightInKg { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Range(ProfileWeightInKgMinValue, ProfileWeightInKgMaxValue, ErrorMessage = "The value must be between {1} and {2}")]
        [Display(Name = "Goal weight in kg")]
        public double GoalWeightInKg { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Range(ProfileBodyMeasurementMinValue, ProfileBodyMeasurementMaxValue, ErrorMessage = "The value must be between {1} and {2}")]
        [Display(Name = "Height in cm")]
        public double HeightInCm { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Range(ProfileBodyMeasurementMinValue, ProfileBodyMeasurementMaxValue, ErrorMessage = "The value must be between {1} and {2}")]
        [Display(Name = "Neck in cm")]
        public double NeckInCm { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Range(ProfileBodyMeasurementMinValue, ProfileBodyMeasurementMaxValue, ErrorMessage = "The value must be between {1} and {2}")]
        [Display(Name = "Waist in cm")]
        public double WaistInCm { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Range(ProfileBodyMeasurementMinValue, ProfileBodyMeasurementMaxValue, ErrorMessage = "The value must be between {1} and {2}")]
        [Display(Name = "Hips in cm")]
        public double HipsInCm { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Range(ProfileDailyIntakeGoalMinValue, ProfileDailyIntakeGoalMaxValue, ErrorMessage = "The value must be between {1} and {2}")]
        [Display(Name = "Daily protein intake goal")]
        public double DailyProteinIntakeGoal { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Range(ProfileDailyIntakeGoalMinValue, ProfileDailyIntakeGoalMaxValue, ErrorMessage = "The value must be between {1} and {2}")]
        [Display(Name = "Daily carbs intake goal")]
        public double DailyCarbohydratesIntakeGoal { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Range(ProfileDailyIntakeGoalMinValue, ProfileDailyIntakeGoalMaxValue, ErrorMessage = "The value must be between {1} and {2}")]
        [Display(Name = "Daily fat intake goal")]
        public double DailyFatIntakeGoal { get; set; }

        [MaxLength(AboutMeMaxLength, ErrorMessage = "Text must have maximum {1} letters")]
        [Display(Name = "About me:")]
        public string AboutMe { get; set; }

        [MaxLength(WhyGetInShapeMaxLength, ErrorMessage = "Text must have maximum {1} letters")]
        [Display(Name = "Why I want to get in shape:")]
        public string WhyGetInShape { get; set; }

        [MaxLength(MyInspirationsMaxLength, ErrorMessage = "Text must have maximum {1} letters")]
        [Display(Name = "My inspirations for getting in shape:")]
        public string MyInspirations { get; set; }

        public double CalculatedDailyCaloriesIntakeGoal => (this.DailyProteinIntakeGoal * 4) + (this.DailyCarbohydratesIntakeGoal * 4) + (this.DailyFatIntakeGoal * 9);

        public string AddedByUserId { get; set; }
    }
}
