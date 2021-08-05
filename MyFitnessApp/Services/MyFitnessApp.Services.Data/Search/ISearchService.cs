namespace MyFitnessApp.Services.Data.Search
{
    using System.Collections.Generic;

    using MyFitnessApp.Web.ViewModels.Search;

    public interface ISearchService
    {
        IEnumerable<FoodViewModel> SearchFoodByKeyword(string keyword);
    }
}
