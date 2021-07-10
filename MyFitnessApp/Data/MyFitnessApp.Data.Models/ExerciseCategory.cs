namespace MyFitnessApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Common.Models;

    using static MyFitnessApp.Common.DataConstants;

    public class ExerciseCategory : BaseDeletableModel<int>
    {
        public ExerciseCategory()
        {
            this.Exercises = new HashSet<Exercise>();
        }

        [Required]
        [MaxLength(ExerciseCategoryNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
