namespace MyFitnessApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Common.Models;

    public class FoodDiary : BaseDeletableModel<int>
    {
        public FoodDiary()
        {
            this.Meals = new HashSet<Meal>();
        }

        // Dropdown Menu
        public WeekDay WeekDay { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }
    }
}
