namespace MyFitnessApp.Web.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.Exercise;
    using MyFitnessApp.Web.Filters;
    using MyFitnessApp.Web.ViewModels.Exercises;

    [Authorize]
    [TypeFilter(typeof(RestrictBannedUsersAttribute))]
    public class ExerciseDiaryController : Controller
    {
        private readonly IExercisesService exercisesService;

        public ExerciseDiaryController(IExercisesService exercisesService)
        {
            this.exercisesService = exercisesService;
        }

        [HttpGet]
        public IActionResult Monday()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var view = new AllDiaryExercisesViewModel
            {
                Exercises = this.exercisesService.GetExercisesByDayOfWeek(userId, "Monday"),
            };

            return this.View(view);
        }

        [HttpGet]
        public IActionResult Tuesday()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var view = new AllDiaryExercisesViewModel
            {
                Exercises = this.exercisesService.GetExercisesByDayOfWeek(userId, "Tuesday"),
            };

            return this.View(view);
        }

        [HttpGet]
        public IActionResult Wednesday()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var view = new AllDiaryExercisesViewModel
            {
                Exercises = this.exercisesService.GetExercisesByDayOfWeek(userId, "Wednesday"),
            };

            return this.View(view);
        }

        [HttpGet]
        public IActionResult Thursday()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var view = new AllDiaryExercisesViewModel
            {
                Exercises = this.exercisesService.GetExercisesByDayOfWeek(userId, "Thursday"),
            };

            return this.View(view);
        }

        [HttpGet]
        public IActionResult Friday()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var view = new AllDiaryExercisesViewModel
            {
                Exercises = this.exercisesService.GetExercisesByDayOfWeek(userId, "Friday"),
            };

            return this.View(view);
        }

        [HttpGet]
        public IActionResult Saturday()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var view = new AllDiaryExercisesViewModel
            {
                Exercises = this.exercisesService.GetExercisesByDayOfWeek(userId, "Saturday"),
            };

            return this.View(view);
        }

        [HttpGet]
        public IActionResult Sunday()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var view = new AllDiaryExercisesViewModel
            {
                Exercises = this.exercisesService.GetExercisesByDayOfWeek(userId, "Sunday"),
            };

            return this.View(view);
        }
    }
}
