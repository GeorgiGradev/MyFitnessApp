namespace MyFitnessApp.Data.Models
{
    using System.Collections.Generic;

    using MyFitnessApp.Data.Common.Models;

    public class Equipment : BaseDeletableModel<int>
    {
        public Equipment()
        {
            this.Exercises = new HashSet<Exercise>();
        }

        public ExerciseEquipment ExerciseEquipment { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
