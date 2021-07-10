namespace MyFitnessApp.Web.ViewModels.Exercises
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Models;

    using static MyFitnessApp.Common.DataConstants;

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

        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public int EquipmentId { get; set; }
    }
}
