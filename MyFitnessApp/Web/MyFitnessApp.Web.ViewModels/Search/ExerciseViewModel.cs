namespace MyFitnessApp.Web.ViewModels.Search
{
    public class ExerciseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int EquipmentId { get; set; } // Необходимо е, за да се подаде към страница, в която ще има списък с определени Equipments

        public string EquipmentName { get; set; }

        public int CategoryId { get; set; } // Необходимо е, за да се подаде към страница, в която ще има списък с определени Categories

        public string CategoryName { get; set; }

        public string DifficultyName { get; set; }

        public string ImageUrl { get; set; }

        public string VideoUrl { get; set; }
    }
}
