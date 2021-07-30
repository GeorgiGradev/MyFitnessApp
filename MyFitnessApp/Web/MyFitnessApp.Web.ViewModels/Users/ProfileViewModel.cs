namespace MyFitnessApp.Web.ViewModels.Users
{
    public class ProfileViewModel
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MemberSince { get; set; }

        public string Gender { get; set; }

        public string ActivityLevel { get; set; }

        public string ImageUrl { get; set; }

        public double CurrentWeightInKg { get; set; }

        public double GoalWeightInKg { get; set; }

        public double HeightInCm { get; set; }

        public double NeckInCm { get; set; }

        public double WaistInCm { get; set; }

        public double HipsInCm { get; set; }

        public double DailyProteinIntakeGoal { get; set; }

        public double DailyCarbohydratesIntakeGoal { get; set; }

        public double DailyFatIntakeGoal { get; set; }

        public string AboutMe { get; set; }

        public string WhyGetInShape { get; set; }

        public string MyInspirations { get; set; }

        public double DailyCaloriesIntakeGoal { get; set; }

        public double FoodDiaryCalories { get; set; }

        public double CaloriesIntakeDifference { get; set; }
    }
}
