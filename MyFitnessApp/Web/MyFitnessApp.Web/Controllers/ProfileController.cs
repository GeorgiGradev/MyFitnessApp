namespace MyFitnessApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ProfileController : Controller
    {
        public IActionResult MyGoals()
        {
            return this.View();
        }
    }
}
