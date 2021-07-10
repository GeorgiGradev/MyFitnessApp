namespace MyFitnessApp.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ExercisesController : Controller
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }
    }
}
