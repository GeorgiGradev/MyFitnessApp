using System.Collections.Generic;

namespace MyFitnessApp.Web.ViewModels.Foods
{
    public class FoodDiaryViewModel
    {
        public IEnumerable<FoodViewModel> Breakfast { get; set; }

        public IEnumerable<FoodViewModel> Lunch { get; set; }

        public IEnumerable<FoodViewModel> Snack { get; set; }

        public IEnumerable<FoodViewModel> Dinner { get; set; }
    }
}
