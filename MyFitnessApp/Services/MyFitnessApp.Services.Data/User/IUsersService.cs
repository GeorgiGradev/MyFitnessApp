namespace MyFitnessApp.Services.Data.User
{
    using MyFitnessApp.Web.ViewModels.Users;

    public interface IUsersService
    {
        string GetUserNameById(string userId);

        string GetUserEmailbyId(string userId);

        public FoundUserViewModel SearchUserByUserName(string userName);

        public FoundUserViewModel SearchUserByEmail(string email);
    }
}
