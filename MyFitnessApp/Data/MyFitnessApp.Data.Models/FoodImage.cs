namespace MyFitnessApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Common.Models;

    public class FoodImage : BaseDeletableModel<string>
    {
        public FoodImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Url { get; set; }

        public string Extension { get; set; }

        public int FoodId { get; set; }

        public virtual Food Food { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}
