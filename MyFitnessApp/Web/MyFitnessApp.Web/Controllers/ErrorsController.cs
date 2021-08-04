namespace MyFitnessApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ErrorsController : Controller
    {
        public IActionResult RestrictedAccess()
        {
            return this.View();
        }
    }
}
