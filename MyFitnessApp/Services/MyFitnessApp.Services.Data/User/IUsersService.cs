namespace MyFitnessApp.Services.Data.User
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyFitnessApp.Web.ViewModels.Administration.Users;
    using MyFitnessApp.Web.ViewModels.Users;

    public interface IUsersService
    {
        string GetUserNameById(string userId);

        string GetUserEmailbyId(string userId);

        public FoundUserViewModel SearchUserByUserName(string userName);

        public FoundUserViewModel SearchUserByEmail(string email);

        int GetCounts();

        IEnumerable<GetAllUsersViewModel> GetAll();

        Task Ban(BanUserInputModel input, string userId);

        Task Unban(string userId);

        bool IsUserBanned(string userId);

        Task Follow(string followerId, string followeeId);

        Task Unfollow(string followerId, string followeeId);

        public bool IsFollowee(string loggedUserId, string searchedUserId);

        IEnumerable<FollowerFolloweeViewModel> GetFollowers(string userId);

        IEnumerable<FollowerFolloweeViewModel> GetFollowees(string userId);
    }
}
