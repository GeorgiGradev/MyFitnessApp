namespace MyFitnessApp.Services.Data.User
{

    public interface IUsersService
    {
        string GetUserNameById(string userId);

        string GetUserEmailbyId(string userId);
    }
}
