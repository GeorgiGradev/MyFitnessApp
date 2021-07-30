namespace MyFitnessApp.Services.Data.User
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyFitnessApp.Web.ViewModels.Users;

    public interface IUsersService
    {
        string GetUserNameById(string userId);

        string GetUserEmailbyId(string userId);

        public IEnumerable<FoundUserViewModel> SearchUserByUserName(string userName);

        public IEnumerable<FoundUserViewModel> SearchUserByEmail(string email);

        public IEnumerable<FoundUserViewModel> SearchUserByFirstName(string firstName);

        public IEnumerable<FoundUserViewModel> SearchUserByLastName(string lastName);

        Task CreateProfileAsync(CreateProfileInputModel model, string userId, string imagePath);

        bool DoesUserHaveProfile(string userId);
    }
}
