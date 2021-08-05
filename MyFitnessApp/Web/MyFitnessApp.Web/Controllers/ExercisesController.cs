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
            // така подаваме на View-то всички EquipmentsCategories в базата, за да се визуализират при празна форма
            var viewModel = new CreateExerciseInputModel();
            viewModel.Categories = this.exercisesService.GetExerciseCategories();
            viewModel.Equipments = this.exercisesService.GetExerciseEquipments();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExerciseInputModel model)
        {
            // Създаваме проверка на валидациите. Ако има грешка върни същото View, за да продължи потребителя с попълването
            if (!this.ModelState.IsValid)
            {
                // Ако има невалидни данни, вземи отново ExerciseCategories преди да визуализираш View-то
                model.Categories = this.exercisesService.GetExerciseCategories();

                // Ако има невалидни данни, вземи отново ExerciseEquipments преди да визуализираш View-то
                model.Equipments = this.exercisesService.GetExerciseEquipments();

                // View-то се връща със заредени всички ExerciseCategories и ExerciseEquipments
                return this.View(model);
            }

            var userId = this.User.GetId(); // специално създаден метод в Web.Infrastructure
            await this.exercisesService.CreateExcerciseAsync(model, userId);

            this.TempData["Message"] = "Exercise created successfully.";

            return this.RedirectToAction("All", "Exercises"); // Да се направи да връща All Exercises
        }

        // Визуализира всички елементи
        [HttpGet]
        public IActionResult All(int id = 1) // id е номера на страницата. Ще го ползваме за пейджирането. (Exercises/All/4)
        {
            const int itemsPerPage = 6;
            var view = new AllExercisesViewModel
            {
                PageNumber = id,
                Exercises = this.exercisesService.GetAllExercises(id, itemsPerPage),
                ExercisesCount = this.exercisesService.GetAllExercisesCount(), // Броят на Exercises ни е нужен за пейджирането, за да знаем коя е последната страница
                ItemsPerPage = itemsPerPage, // дава информация колко Exercises има на една стрница
            };

            return this.View(view);
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            var viewNodel = this.exercisesService.GetExerciseById(id); // вътре са данните за визуализация
            return this.View(viewNodel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddExerciseInputModel model, int id)
        {
            if (!this.ModelState.IsValid)
            {
                var viewNodel = this.exercisesService.GetExerciseById(id); // вътре са данните за визуализация
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

        [HttpGet]
        public IActionResult MyExercises()
        {
            var userId = this.User.GetId();
            var view = new AllExercisesViewModel
            {
                Exercises = this.exercisesService.GetAllExercisesByUserId(userId),
            };

            return this.View(view);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var userId = this.User.GetId();
            await this.exercisesService.RemoveExerciseAsync(userId, id);
            return this.RedirectToAction("Monday", "ExerciseDiary");
        }
    }
}
