namespace MyFitnessApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.Exercise;
    using MyFitnessApp.Web.ViewModels.Exercises;

    public class ExercisesController : Controller
    {
        private readonly IExercisesService exercisesService;

        public ExercisesController(IExercisesService exercisesService)
        {
            this.exercisesService = exercisesService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            var view = new CreateExerciseInputModel
            {
                Categories = this.exercisesService.GetExerciseCategories(), // така подаваме на View-то всичко Exercise категории в базата
            };
            return this.View(view);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateExerciseInputModel model)
        {
            return this.View();
        }
    }
}
