namespace MyFitnessApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Common.Models;

    public class Exercise : BaseDeletableModel<int>
    {
        public Exercise()
        {
            this.Images = new HashSet<ExerciseImage>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [MaxLength(500)]
        public string Instructions { get; set; }

        public int Repetitions { get; set; }

        public int Sets { get; set; }

        public double Weight { get; set; }

        public ExerciseDifficulty Difficulty { get; set; }

        public TimeSpan DurationInMinutes { get; set; }

        public double CaloriesBurned { get; set; }

        public int EquipmentId { get; set; }

        public virtual Equipment Equipment { get; set; }

        public int TrainingDayId { get; set; }

        public virtual TrainingDay TrainingDay { get; set; }

        public virtual ICollection<ExerciseImage> Images { get; set; }
    }
}
