namespace MyFitnessApp.Web.ViewModels.Foods
{
    using System.Collections.Generic;

    public class AllFoodsViewModel : PagingViewModel
    {
        public IEnumerable<FoodViewModel> Foods { get; set; }
    }
}
