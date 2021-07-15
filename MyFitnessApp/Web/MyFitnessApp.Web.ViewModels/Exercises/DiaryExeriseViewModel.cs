namespace MyFitnessApp.Web.ViewModels.Exercises
{
    public class DiaryExeriseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string DayOfWeek { get; set; }

        public int Repetitions { get; set; }

        public int Sets { get; set; }

        public double Weight { get; set; }

        public string ImageUrl { get; set; }

        public int ExerciseId { get; set; }
    }
}
