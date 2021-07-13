namespace MyFitnessApp.Web.ViewModels.Exercises
{
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Mapping;
 
    // Визуализира едно упражнение
    public class SingleExerciseViewModel : IMapFrom<Exercise> // , IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int EquipmentId { get; set; } // Необходимо е, за да се подаде към страница, в която ще има списък с определени Equipments

        public string EquipmentName { get; set; }

        public int CategoryId { get; set; } // Необходимо е, за да се подаде към страница, в която ще има списък с определени Categories

        public string CategoryName { get; set; }

        public string DifficultyName { get; set; }

        public string ImageUrl { get; set; }

        public string VideoUrl { get; set; }

        public string AddedByUserId { get; set; }

        ////  => Във случай, че имаме допълнителна логика, която не може да бъде разбрана от AutoMapper-а ////
        // public void CreateMappings(IProfileExpression configuration)
        // {
        //     throw new System.NotImplementedException();
        // }
    }
}