namespace MyFitnessApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Common.Models;

    public class TrainingDay : BaseDeletableModel<int>
    {
        public TrainingDay()
        {
            this.Exercises = new HashSet<Exercise>();
        }

        public DayOfWeek Name { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
