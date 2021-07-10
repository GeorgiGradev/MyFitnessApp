namespace MyFitnessApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ExercisesController : Controller
    {
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        // [HttpPost]
        // [Authorize]
        // public IActionResult Create()
        // {
        //     return this.View();
        // }
    }
}
