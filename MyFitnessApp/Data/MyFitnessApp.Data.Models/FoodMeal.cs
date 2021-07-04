namespace MyFitnessApp.Data.Models
{
    public class FoodMeal
    {
        public int Id { get; set; }

        public int MealId { get; set; }

        public virtual Meal Meal { get; set; }

        public int FoodId { get; set; }

        public virtual Food Food { get; set; }
    }
}
