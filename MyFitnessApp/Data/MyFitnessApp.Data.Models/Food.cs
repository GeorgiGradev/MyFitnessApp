namespace MyFitnessApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyFitnessApp.Data.Common.Models;

    using static MyFitnessApp.Common.DataConstants;

    public class Food : BaseDeletableModel<int>
    {
        public Food()
        {
            this.FoodMeals = new HashSet<FoodMeal>();
        }

        [Required]
        [MaxLength(FoodNameMaxLength)]
        public string Name { get; set; }

        [Range(FoodNutritionMinValue, FoodNutritionMaxValue)]

        [Required]
        [MaxLength(FoodBrandNameMaxLength)]
        public string Brand { get; set; }

        public double ProteinInGrams { get; set; }

        [Range(FoodNutritionMinValue, FoodNutritionMaxValue)]
        public double CarbohydratesInGrams { get; set; }

        [Range(FoodNutritionMinValue, FoodNutritionMaxValue)]
        public double FatInGrams { get; set; }

        public double CalculatedTotalCalories => (this.ProteinInGrams * 4) + (this.CarbohydratesInGrams * 4) + (this.FatInGrams * 9);

        [Range(FoodNutritionMinValue, FoodNutritionMaxValue)]
        public double SugarsInGrams { get; set; }

        [Range(FoodNutritionMinValue, FoodNutritionMaxValue)]
        public double FiberInGrams { get; set; }

        [Range(FoodNutritionMinValue, FoodNutritionMaxValue)]
        public double CholesterolInMg { get; set; }

        [Range(FoodNutritionMinValue, FoodNutritionMaxValue)]
        public double SoduimInMg { get; set; }

        [Range(FoodNutritionMinValue, FoodNutritionMaxValue)]
        public double PotasiumInMg { get; set; }

        [Range(FoodNutritionMinValue, FoodNutritionMaxValue)]
        public double VitaminAInPercents { get; set; }

        [Range(FoodNutritionInPercentsMinValue, FoodNutritionInPercentsMaxValue)]
        public double VitaminCInPercents { get; set; }

        [Range(FoodNutritionInPercentsMinValue, FoodNutritionInPercentsMaxValue)]
        public double CalciumInPercents { get; set; }

        [Range(FoodNutritionInPercentsMinValue, FoodNutritionInPercentsMaxValue)]
        public double IronInPercents { get; set; }

        [Range(FoodQuantityInGramsMinValue, FoodQuantityInGramsMaxValue)]
        public double ServingSizeInGrams { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<FoodMeal> FoodMeals { get; set; }
    }
}
