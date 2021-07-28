namespace MyFitnessApp.Web.ViewModels.Foods
{
    using System.Collections.Generic;

    public class AllFoodsViewModel
    {
        public IEnumerable<FoodViewModel> Foods { get; set; }
    }
}
