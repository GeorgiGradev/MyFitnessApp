namespace MyFitnessApp.Web.ViewModels.Exercises
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Models;

    using static MyFitnessApp.Common.DataConstants;

    //// Приема даннните, въведени от потребителя при Create New Exercise \\\\
    public class CreateExerciseInputModel 
    {
        [Required]
        [MaxLength(ExerciseNameMaxLength)]
        [Display(Name = "Exercise name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(ExerciseDescriptionMaxLength)]
        public string Description { get; set; }

        // Dropdown Menu
        public ExerciseDifficulty Difficulty { get; set; }

        [Required]
        [Url]
        [Display(Name = "Image url")]
        public string ImageUrl { get; set; }

        [Required]
        [Url]
        [Display(Name = "Video url")]
        public string VideoUrl { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        // Взима всички ExerciseCategories, за да ги подаде на падащото меню
        public IEnumerable<CategoryViewModel> Categories { get; set; }

        // Взима всички ЕxerciseEquipments, за да ги подаде на падащото меню
        // ........................

        public int EquipmentId { get; set; }
    }
}
