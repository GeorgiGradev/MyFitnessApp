namespace MyFitnessApp.Data.Models
{
    using System.Collections.Generic;

    using MyFitnessApp.Data.Common.Models;

    public class ExerciseCategory : BaseDeletableModel<int>
    {
        public ExerciseCategory()
        {
            this.Exercises = new HashSet<Exercise>();
        }

        // Dropdown Men
        public CategoryName Name { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
