namespace MyFitnessApp.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.Exercise;
    using MyFitnessApp.Web.Filters;
    using MyFitnessApp.Web.ViewModels.Exercises;

    [Authorize]
    [TypeFilter(typeof(RestrictBannedUsersAttribute))]
    [TypeFilter(typeof(RestrictUsersWithoutProfileAttribute))]
    public class ExercisesController : Controller
    {
        private readonly IExercisesService exercisesService;

        public ExercisesController(IExercisesService exercisesService)
        {
            this.exercisesService = exercisesService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CreateExerciseInputModel();
            viewModel.Categories = this.exercisesService.GetExerciseCategories();
            viewModel.Equipments = this.exercisesService.GetExerciseEquipments();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExerciseInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Categories = this.exercisesService.GetExerciseCategories();
                model.Equipments = this.exercisesService.GetExerciseEquipments();

                return this.View(model);
            }

            var userId = this.User.GetId();
            await this.exercisesService.CreateExcerciseAsync(model, userId);

            this.TempData["Message"] = "Exercise created successfully.";

            return this.RedirectToAction("All", "Exercises");
        }

        [HttpGet]
        public IActionResult All(int id = 1) 
        {
            const int itemsPerPage = 6;
            var view = new AllExercisesViewModel
            {
                PageNumber = id,
                Exercises = this.exercisesService.GetAllExercises(id, itemsPerPage),
                ItemsCount = this.exercisesService.GetCounts(),
                ItemsPerPage = itemsPerPage,
            };

            return this.View(view);
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            var viewNodel = this.exercisesService.GetExerciseById(id);
            return this.View(viewNodel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddExerciseInputModel model, int id)
        {
            if (!this.ModelState.IsValid)
            {
                var viewNodel = this.exercisesService.GetExerciseById(id);
                return this.View(viewNodel);
            }

            var userId = this.User.GetId();
            await this.exercisesService.AddExerciseToUserAsync(model, userId);
            var dayOfWeek = model.WeekDay.ToString();

            this.TempData["Message"] = "Exercise added to my diary.";

            return this.RedirectToAction(dayOfWeek, "ExerciseDiary");
        }

        [HttpGet]
        public IActionResult Categories()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id, string day)
        {
            var userId = this.User.GetId();
            await this.exercisesService.RemoveExerciseAsync(userId, id);
            return this.Redirect($"/ExerciseDiary/{day}");
        }
    }
}
