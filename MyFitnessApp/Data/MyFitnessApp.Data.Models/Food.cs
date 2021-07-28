namespace MyFitnessApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Common.Models;

    using static MyFitnessApp.Common.DataConstants;

    public class Food : BaseDeletableModel<int>
    {
        public Food()
        {
            this.FoodMeals = new HashSet<FoodMeal>();
        }

        [Required]
        [MaxLength(FoodNameMaxLength)]
        public string Name { get; set; }

        [Range(FoodNutritionMinValue, FoodNutritionMaxValue)]
        public double ProteinIn100Grams { get; set; }

        [Range(FoodNutritionMinValue, FoodNutritionMaxValue)]
        public double CarbohydratesIn100Grams { get; set; }

        [Range(FoodNutritionMinValue, FoodNutritionMaxValue)]
        public double FatIn100Grams { get; set; }

        public double TotalCalories { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<FoodMeal> FoodMeals { get; set; }
    }
}
