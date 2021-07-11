﻿namespace MyFitnessApp.Web.Controllers
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
        public IActionResult Create()
        {
            // така подаваме на View-то всички EquipmentsCategories в базата, за да се визуализират при празна форма
            var view = new CreateExerciseInputModel();
            view.Categories = this.exercisesService.GetExerciseCategories();
            view.Equipments = this.exercisesService.GetExerciseEquipments();

            return this.View(view);
        }

        [HttpPost]
        public IActionResult Create(CreateExerciseInputModel model)
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

            return this.RedirectToAction("Index", "Home");
        }
    }
}
