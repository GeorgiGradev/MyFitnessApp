namespace MyFitnessApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : Controller
    {
        public IActionResult MyGoals()
        {
            return this.View();
        }
    }
}
