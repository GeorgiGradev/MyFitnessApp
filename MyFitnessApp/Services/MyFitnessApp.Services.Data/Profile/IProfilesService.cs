using MyFitnessApp.Web.ViewModels.Profiles;
using System.Threading.Tasks;

namespace MyFitnessApp.Services.Data.Profile
{
    public interface IProfilesService
    {
        Task CreateProfileAsync(CreateProfileInputModel model, string userId, string imagePath);

        bool DoesUserHaveProfile(string userId);

        ProfileViewModel GetProfileData(string userId);


    }
}
