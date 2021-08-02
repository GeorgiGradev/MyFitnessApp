namespace MyFitnessApp.Services.Data.User
{
    using System.Collections.Generic;

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
    }
}
