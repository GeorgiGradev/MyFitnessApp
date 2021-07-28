namespace MyFitnessApp.Web.ViewModels.Foods
{
    public class FoodViewModel
    {
        public string Name { get; set; }

        public double ProteinIn100Grams { get; set; }

        public double CarbohydratesIn100Grams { get; set; }

        public double FatIn100Grams { get; set; }

        public double TotalCalories { get; set; }

        public string Url => $"/Foods/ByName/{this.Name.Replace(' ', '-')}";
    }
}
