namespace MyFitnessApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ErrorsController : Controller
    {
        [HttpGet]
        public IActionResult RestrictedAccess()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult NoProfile()
        {
            return this.View();
        }
    }
}
