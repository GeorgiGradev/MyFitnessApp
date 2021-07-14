namespace MyFitnessApp.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Data;
    using MyFitnessApp.Web.ViewModels;
    using MyFitnessApp.Web.ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            // За да се визуализират данните на началната страница
            var viewModel = new IndexViewModel
            {
                Exercises = this.db.Exercises,
                Foods = this.db.Foods,
                UsersCount = this.db.Users.Count(),
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
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
