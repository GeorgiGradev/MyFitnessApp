namespace MyFitnessApp.Web.ViewModels.Search
{
    public class ExerciseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int EquipmentId { get; set; }

        public string EquipmentName { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string DifficultyName { get; set; }

        public string ImageUrl { get; set; }

        public string VideoUrl { get; set; }
    }
}
