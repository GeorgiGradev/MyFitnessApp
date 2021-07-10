namespace MyFitnessApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Common.Models;

    public class TrainingDiary : BaseDeletableModel<int>
    {
        public TrainingDiary()
        {
            this.TrainingDiaryExercises = new HashSet<TrainingDiaryExercise>();
        }

        // Dropdown Menu
        public DayOfWeek DayOfWeekName { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<TrainingDiaryExercise> TrainingDiaryExercises { get; set; }
    }
}
