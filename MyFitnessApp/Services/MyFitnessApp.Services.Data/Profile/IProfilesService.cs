namespace MyFitnessApp.Services.Data.Profile
{
    using System.Threading.Tasks;

    using MyFitnessApp.Web.ViewModels.Profiles;

    public interface IProfilesService
    {
        Task CreateProfileAsync(CreateProfileInputModel model, string userId, string imagePath);

        bool DoesUserHaveProfile(string userId);

        ProfileViewModel GetProfileData(string userId);

        string GetInternalImagePath(string userId);
    }
}
