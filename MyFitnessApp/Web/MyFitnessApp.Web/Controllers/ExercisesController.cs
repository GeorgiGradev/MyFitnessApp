﻿namespace MyFitnessApp.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

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
            // така подаваме на View-то всички EquipmentsCategories в базата, за да се визуализират при празна форма
            var view = new CreateExerciseInputModel();
            view.Categories = this.exercisesService.GetExerciseCategories();
            view.Equipments = this.exercisesService.GetExerciseEquipments();

            return this.View(view);
        }

        [HttpPost]
        [Authorize]
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

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.exercisesService.CreateExcerciseAsync(model, userId);

            return this.RedirectToAction("Index", "Home"); // Да се направи да връща All Exercises
        }

        // Визуализира всички елементи
        [HttpGet]
        [Authorize]
        public IActionResult All(int id = 1) // id е номера на страницата. Ще го ползваме за пейджирането. (Exercises/All/4)
        {
            const int itemsPerPage = 9;
            var viewModel = new AllExercisesViewModel
            {
                PageNumber = id,
                Exercises = this.exercisesService.GetAllExercises(id, itemsPerPage),
                ExercisesCount = this.exercisesService.GetAllExercisesCount(), // Броят на Exercises ни е нужен за пейджирането, за да знаем коя е последната страница
                ItemsPerPage = itemsPerPage, // дава информация колко Exercises има на една стрница
            };

            return this.View(viewModel);
        }

        public IActionResult Details()
        {
            var vuewNidel = this.exercisesService.GetTestExercise();
            return this.View(vuewNidel);
        }

    }
}
