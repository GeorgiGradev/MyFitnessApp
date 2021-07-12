namespace MyFitnessApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Common.Models;

    using static MyFitnessApp.Common.DataConstants;

    public class Exercise : BaseDeletableModel<int>
    {
        public Exercise()
        {
            this.UserExercises = new HashSet<UserExercise>();
        }

        [Required]
        [MaxLength(ExerciseNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ExerciseDescriptionMaxLength)]
        public string Description { get; set; }

        // Dropdown Menu
        public ExerciseDifficulty Difficulty { get; set; }

        public int CategoryId { get; set; }

        // Dropdown Menu
        public ExerciseCategory Category { get; set; }

        public int EquipmentId { get; set; }

        // Dropdown Menu
        public ExerciseEquipment Equipment { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        [Url]
        public string VideoUrl { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<UserExercise> UserExercises { get; set; }
    }
}
