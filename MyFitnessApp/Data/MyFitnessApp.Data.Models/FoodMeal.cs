namespace MyFitnessApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Common.Models;

    using static MyFitnessApp.Common.DataConstants;

    public class FoodMeal : BaseDeletableModel<int>
    {
        public int MealId { get; set; }

        public virtual Meal Meal { get; set; }

        public int FoodId { get; set; }

        public virtual Food Food { get; set; }

        [Range(FoodQuantityInGramsMinValue, FoodQuantityInGramsMaxValue)]
        public double ServingSizeInGrams { get; set; }
    }
}
