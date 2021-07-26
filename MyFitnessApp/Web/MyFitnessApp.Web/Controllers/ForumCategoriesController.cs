namespace MyFitnessApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.Forum;

    public class ForumCategoriesController : Controller
    {
        private readonly IForumsService forumsService;

        public ForumCategoriesController(IForumsService forumsService)
        {
            this.forumsService = forumsService;
        }

        public IActionResult ByName(string name)
        {
            var viewModel = this.forumsService.GetCategoryByName(name);

            return this.View(viewModel);
        }
    }
}
