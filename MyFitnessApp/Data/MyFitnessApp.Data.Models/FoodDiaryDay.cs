namespace MyFitnessApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Common.Models;

    public class FoodDiaryDay : BaseDeletableModel<int>
    {
        public FoodDiaryDay()
        {
            this.Meals = new HashSet<Meal>();
        }

        // Dropdown Menu
        public DayOfWeek Name { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }
    }
}
