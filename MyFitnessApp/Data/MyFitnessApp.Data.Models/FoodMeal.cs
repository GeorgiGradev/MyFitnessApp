namespace MyFitnessApp.Data.Models
{
    using MyFitnessApp.Data.Common.Models;

    public class FoodMeal : BaseDeletableModel<int>
    {
        public int MealId { get; set; }

        public virtual Meal Meal { get; set; }

        public int FoodId { get; set; }

        public virtual Food Food { get; set; }
    }
}
