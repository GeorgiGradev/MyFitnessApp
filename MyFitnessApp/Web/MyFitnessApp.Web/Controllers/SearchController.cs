namespace MyFitnessApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.Search;
    using MyFitnessApp.Web.Filters;
    using MyFitnessApp.Web.ViewModels.Search;
    using System.Linq;

    [Authorize]
    [TypeFilter(typeof(RestrictBannedUsersAttribute))]
    [TypeFilter(typeof(RestrictUsersWithoutProfileAttribute))]
    public class SearchController : Controller
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }


        [HttpGet]
        public IActionResult SearchFood()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult SearchFood(FoodInputModel model)
        {
            var foods = this.searchService.SearchFoodByKeyword(model.Keyword);
            if (foods.Count() != 0)
            {
                var viewModel = new AllFoodsViewModel
                {
                    Foods = foods,
                };
                return this.View("FoundFood", viewModel);
            }
            else
            {
                this.TempData["Message"] = "There was no food found with the given keyword.";
                return this.View();
            }
        }
    }
}
