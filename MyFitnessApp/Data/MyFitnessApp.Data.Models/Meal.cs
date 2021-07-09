namespace MyFitnessApp.Data.Models
{
    using System.Collections.Generic;

    using MyFitnessApp.Data.Common.Models;

    public class Meal : BaseDeletableModel<int>
    {
        public Meal()
        {
            this.FoodMeals = new HashSet<FoodMeal>();
        }

        // Dropdown Menu
        public MealName Name { get; set; }

        public int FoodDiaryId { get; set; }

        public virtual FoodDiary FoodDiary { get; set; }

        public virtual ICollection<FoodMeal> FoodMeals { get; set; }
    }
}
