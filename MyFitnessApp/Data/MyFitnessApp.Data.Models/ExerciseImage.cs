namespace MyFitnessApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Common.Models;

    public class ExerciseImage : BaseDeletableModel<string>
    {
        public ExerciseImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Url { get; set; }

        public string Extension { get; set; }

        public int ExerciseId { get; set; }

        public virtual Exercise Exercise { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}
