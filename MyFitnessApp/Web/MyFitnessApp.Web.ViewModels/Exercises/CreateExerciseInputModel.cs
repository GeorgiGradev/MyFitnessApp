namespace MyFitnessApp.Web.ViewModels.Exercises
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Models;

    using static MyFitnessApp.Common.DataConstants;

    public class CreateExerciseInputModel
    {
        [Required(ErrorMessage = "The field is required")]
        [MinLength(ExerciseNameMinLength, ErrorMessage = "The name must have at least {1} letters ")]
        [MaxLength(ExerciseNameMaxLength, ErrorMessage = "The name must have maximum {1} letters ")]
        [Display(Name = "Exercise name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [MinLength(ExerciseDescriptionMinLength, ErrorMessage = "The description must have at least {1} letters")]
        [MaxLength(ExerciseDescriptionMaxLength, ErrorMessage = "The description must have maximum {1} letters")]
        public string Description { get; set; }

        // Dropdown Menu
        [Display(Name = "Choose difficulty")]
        public ExerciseDifficulty Difficulty { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Url]
        [Display(Name = "Image url (.jpg only)")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Url]
        [Display(Name = "YouTube video url")]
        public string VideoUrl { get; set; }

        [Display(Name = "Choose category")]
        public int CategoryId { get; set; }

        // Dropdown Menu
        public IEnumerable<CategoryViewModel> Categories { get; set; }

        [Display(Name = "Choose equipment")]
        public int EquipmentId { get; set; }

        // Dropdown Menu
        public IEnumerable<EquipmentViewModel> Equipments { get; set; }
    }
}
