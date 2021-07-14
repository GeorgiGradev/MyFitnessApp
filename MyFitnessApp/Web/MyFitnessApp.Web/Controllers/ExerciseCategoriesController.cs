namespace MyFitnessApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.Exercise;
    using MyFitnessApp.Web.ViewModels.Exercises;

    public class ExerciseCategoriesController : Controller
    {
        private readonly IExercisesService exercisesService;

        public ExerciseCategoriesController(IExercisesService exercisesService)
        {
            this.exercisesService = exercisesService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Shoulders()
        {
            var view = new AllExercisesViewModel
            {
                Exercises = this.exercisesService.GetExercisesByCategoryId(1),
            };

            return this.View(view);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Triceps()
        {
            var view = new AllExercisesViewModel
            {
                Exercises = this.exercisesService.GetExercisesByCategoryId(2),
            };

            return this.View(view);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Biceps()
        {
            var view = new AllExercisesViewModel
            {
                Exercises = this.exercisesService.GetExercisesByCategoryId(3),
            };

            return this.View(view);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Back()
        {
            var view = new AllExercisesViewModel
            {
                Exercises = this.exercisesService.GetExercisesByCategoryId(4),
            };

            return this.View(view);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Chest()
        {
            var view = new AllExercisesViewModel
            {
                Exercises = this.exercisesService.GetExercisesByCategoryId(5),
            };

            return this.View(view);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Forearm()
        {
            var view = new AllExercisesViewModel
            {
                Exercises = this.exercisesService.GetExercisesByCategoryId(6),
            };

            return this.View(view);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Traps()
        {
            var view = new AllExercisesViewModel
            {
                Exercises = this.exercisesService.GetExercisesByCategoryId(7),
            };

            return this.View(view);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Abs()
        {
            var view = new AllExercisesViewModel
            {
                Exercises = this.exercisesService.GetExercisesByCategoryId(8),
            };

            return this.View(view);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Glutes()
        {
            var view = new AllExercisesViewModel
            {
                Exercises = this.exercisesService.GetExercisesByCategoryId(9),
            };

            return this.View(view);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Quadriceps()
        {
            var view = new AllExercisesViewModel
            {
                Exercises = this.exercisesService.GetExercisesByCategoryId(10),
            };

            return this.View(view);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Hamstrings()
        {
            var view = new AllExercisesViewModel
            {
                Exercises = this.exercisesService.GetExercisesByCategoryId(11),
            };

            return this.View(view);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Calves()
        {
            var view = new AllExercisesViewModel
            {
                Exercises = this.exercisesService.GetExercisesByCategoryId(12),
            };

            return this.View(view);
        }
    }
}
