namespace MyFitnessApp.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.Forum;
    using MyFitnessApp.Web.ViewModels.Forum;

    public class ForumsController : Controller
    {
        private readonly IForumsService forumsService;

        public ForumsController(IForumsService forumsService)
        {
            this.forumsService = forumsService;
        }

        [Authorize]
        public IActionResult Categories()
        {
            var categories = this.forumsService.GetAllCategories();
            var viewModel = new AllCategoriesViewModel
            {
                Categories = categories,
            };

            return this.View(viewModel);
        }
    }
}
