namespace MyFitnessApp.Web.ViewModels.Exercises
{
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Mapping;

    public class ExerciseViewModel : IMapFrom<Exercise> // , IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int EquipmentId { get; set; }

        public string EquipmentName { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Difficulty { get; set; }

        public string ImageUrl { get; set; }

        public string VideoUrl { get; set; }

        public string AddedByUserId { get; set; }

        // public void CreateMappings(IProfileExpression configuration)
        // {
        //     throw new System.NotImplementedException();
        // }
    }
}
