namespace MyFitnessApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Common.Models;

    using static MyFitnessApp.Common.DataConstants;

    public class ExerciseEquipment : BaseDeletableModel<int>
    {
        public ExerciseEquipment()
        {
            this.Exercises = new HashSet<Exercise>();
        }

        [Required]
        [MaxLength(ExerciseEquipmentNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
