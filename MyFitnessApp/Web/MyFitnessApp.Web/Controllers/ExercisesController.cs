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
                // така подаваме на View-то всички ExerciseCategories в базата, за да се визуализират при празна форма
                Categories = this.exercisesService.GetExerciseCategories(),

                // така подаваме на View-то всички EquipmentsCategories в базата, за да се визуализират при празна форма
                // ..................

                // така подаваме на View-то всички ExerciseDifficulty (ENUM) в базата, за да се визуализират при празна форма
                // ..................
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
