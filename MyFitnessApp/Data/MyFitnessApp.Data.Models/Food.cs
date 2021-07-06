namespace MyFitnessApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Common.Models;

    public class Food : BaseDeletableModel<int>
    {
        public Food()
        {
            this.FoodImages = new HashSet<FoodImage>();
            this.FoodMeals = new HashSet<FoodMeal>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public double Protein { get; set; }

        public double Carbohydrates { get; set; }

        public double Fat { get; set; }

        public double CalculatedTotalCalories => (this.Protein * 4) + (this.Carbohydrates * 4) + (this.Fat * 9);

        public double Sugars { get; set; }

        public double DietaryFiber { get; set; }

        public double Salt { get; set; }

        public double Cholesterol { get; set; }

        public double Soduim { get; set; }

        public double Potasium { get; set; }

        public double VitaminA { get; set; }

        public double VitaminC { get; set; }

        public double Calcium { get; set; }

        public double Iron { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<FoodImage> FoodImages { get; set; }

        public virtual ICollection<FoodMeal> FoodMeals { get; set; }
    }
}
