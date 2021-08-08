namespace MyFitnessApp.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Web.ViewModels;
    using MyFitnessApp.Web.ViewModels.Home;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
            };
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Terms()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult CommunityGuidelines()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
