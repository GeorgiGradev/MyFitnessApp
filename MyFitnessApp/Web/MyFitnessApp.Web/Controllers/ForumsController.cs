namespace MyFitnessApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.Forum;
    using MyFitnessApp.Web.Filters;
    using MyFitnessApp.Web.ViewModels.Forum;

    [Authorize]
    [TypeFilter(typeof(RestrictBannedUsersAttribute))]
    [TypeFilter(typeof(RestrictUsersWithoutProfileAttribute))]
    public class ForumsController : Controller
    {
        private readonly IForumsService forumsService;

        public ForumsController(IForumsService forumsService)
        {
            this.forumsService = forumsService;
        }

        [HttpGet]
        public IActionResult Categories()
        {
            var categories = this.forumsService.GetAllCategories();
            var viewModel = new AllCategoriesViewModel
            {
                Categories = categories,
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult ByName(string name)
        {
            var viewModel = this.forumsService.GetCategoryByName(name);

            return this.View(viewModel);
        }
    }
}
