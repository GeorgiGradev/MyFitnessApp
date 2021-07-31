namespace MyFitnessApp.Services.Data.Profile
{
    using MyFitnessApp.Web.ViewModels.Profiles;
    using System.Threading.Tasks;

    public interface IProfilesService
    {
        Task CreateProfileAsync(CreateProfileInputModel model, string userId, string imagePath);

        bool DoesUserHaveProfile(string userId);

        ProfileViewModel GetProfileData(string userId);

        string GetInternalImagePath(string userId);
    }
}
