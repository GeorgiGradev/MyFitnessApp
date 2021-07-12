namespace MyFitnessApp.Web.ViewModels.Exercises
{
    //// Визуализира едно упражнение
    public class ExerciseViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string EquipmentId { get; set; } // Необходимо е, за да се подаде към страница, в която ще има списък с определени Equipments

        public string EquipmentName { get; set; }

        public string CategoryId { get; set; } // Необходимо е, за да се подаде към страница, в която ще има списък с определени Categories

        public string CategoryName { get; set; }

        public string DifficultyName { get; set; }

        public string ImageUrl { get; set; }

        public string VideoUrl { get; set; }

        public string AddedByUserId { get; set; }
    }
}