namespace MyFitnessApp.Web.ViewModels.Foods
{
    using System.Collections.Generic;

    public class FoodDiaryViewModel
    {
        public List<FoodViewModel> Breakfast { get; set; }

        public List<FoodViewModel> Lunch { get; set; }

        public List<FoodViewModel> Snack { get; set; }

        public List<FoodViewModel> Dinner { get; set; }
    }
}
