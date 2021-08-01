namespace MyFitnessApp.Web.ViewModels.Users
{
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Mapping;

    public class FoundUserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string UserProfileImage { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
