namespace MyFitnessApp.Web.ViewModels.Foods
{
    using System.Collections.Generic;

    public class DinnerViewModel
    {
        public IEnumerable<FoodViewModel> DinnerFoods { get; set; }
    }
}
