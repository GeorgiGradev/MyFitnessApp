namespace MyFitnessApp.Services.Data.Profile
{
    using System.Threading.Tasks;

    using MyFitnessApp.Web.ViewModels.Profiles;

    public interface IProfilesService
    {
        Task CreateProfileAsync(CreateProfileInputModel model, string userId, string imagePath);

        bool DoesUserHaveProfile(string userId);

        ProfileViewModel GetProfileData(string userId);

        string GetUserIdByUserName(string userName);

        Task EditProfileAsync(EditProfileInputModel model, string userId);

        Task EditProfileImageAsync(EditProfileImageInputModel model, string userId, string imagePath);

        public EditProfileInputModel GetProfileDataForUpdate(string userId);

        int GetPofileIdByUserId(string userId);
    }
}
