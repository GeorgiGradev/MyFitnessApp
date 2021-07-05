namespace MyFitnessApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Identity;
    using MyFitnessApp.Data.Common.Models;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.TrainingDays = new HashSet<TrainingDay>();
            this.FoodDiaryDays = new HashSet<FoodDiaryDay>();
            this.Foods = new HashSet<Food>();
            this.FoodImages = new HashSet<FoodImage>();
            this.ExerciseImages = new HashSet<ExerciseImage>();
            this.UserImages = new HashSet<UserImage>();
        }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public Gender? Gender { get; set; }

        public double? HeightInCentimeters { get; set; }

        public double? CurrentWeight { get; set; }

        public double? GoalWeight { get; set; }

        public ActivityLevel? ActivityLevel { get; set; }

        public double? DailyProteinIntakeGoal { get; set; }

        public double? DailyCarbohydratesIntakeGoal { get; set; }

        public double? DailyFatIntakeGoal { get; set; }

        public double? CalculatedDailyCaloriesIntakeGoal => (this.DailyProteinIntakeGoal * 4) + (this.DailyCarbohydratesIntakeGoal * 4) + (this.DailyFatIntakeGoal * 9);

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<TrainingDay> TrainingDays { get; set; }

        public virtual ICollection<FoodDiaryDay> FoodDiaryDays { get; set; }

        public virtual ICollection<Food> Foods { get; set; }

        public virtual ICollection<UserImage> UserImages { get; set; }

        public virtual ICollection<FoodImage> FoodImages { get; set; }

        public virtual ICollection<ExerciseImage> ExerciseImages { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
