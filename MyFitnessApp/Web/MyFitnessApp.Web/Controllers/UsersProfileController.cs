namespace MyFitnessApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class UsersProfileController : Controller
    {
        public IActionResult MyGoals()
        {
            return this.View();
        }
    }
}
