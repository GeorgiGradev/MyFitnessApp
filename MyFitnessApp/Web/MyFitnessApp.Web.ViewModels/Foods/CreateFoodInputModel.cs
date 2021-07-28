namespace MyFitnessApp.Web.ViewModels.Foods
{
    using System.ComponentModel.DataAnnotations;

    using static MyFitnessApp.Common.DataConstants;

    public class CreateFoodInputModel
    {
        [Required(ErrorMessage = "The field is required")]
        [MinLength(FoodNameMinLength, ErrorMessage = "The name must have at least {1} letters ")]
        [MaxLength(FoodNameMaxLength, ErrorMessage = "The name must have at least {1} letters ")]
        [Display(Name = "Food name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Range(FoodNutritionMinValue, FoodNutritionMaxValue, ErrorMessage = "The value must be between 0 and 20000")]
        [Display(Name = "Protein content in 100 grams")]
        public double ProteinIn100Grams { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Range(FoodNutritionMinValue, FoodNutritionMaxValue, ErrorMessage = "The value must be between 0 and 20000")]
        [Display(Name = "Carbohydrates content in 100 grams")]
        public double CarbohydratesIn100Grams { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Range(FoodNutritionMinValue, FoodNutritionMaxValue, ErrorMessage = "The value must be between 0 and 20000")]
        [Display(Name = "Fat content in 100 grams")]
        public double FatIn100Grams { get; set; }

        public double CalculatedTotalCalories => (this.ProteinIn100Grams * 4) + (this.CarbohydratesIn100Grams * 4) + (this.FatIn100Grams * 9);
    }
}
