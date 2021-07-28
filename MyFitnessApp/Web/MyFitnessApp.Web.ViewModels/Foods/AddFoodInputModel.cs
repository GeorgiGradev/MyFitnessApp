namespace MyFitnessApp.Web.ViewModels.Foods
{
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Models;

    using static MyFitnessApp.Common.DataConstants;

    public class AddFoodInputModel
    {
        public string Name { get; set; }

        // Dropdown Menu
        [Display(Name = "Meal name")]
        public MealName MealName { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Range(FoodQuantityInGramsMinValue, FoodQuantityInGramsMaxValue, ErrorMessage ="Quantity must be in range between 1 and 5000")]
        [Display(Name = "Quantity in grams")]
        public double ServingSize { get; set; }
    }
}
