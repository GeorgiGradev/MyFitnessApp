namespace MyFitnessApp.Services.Data.User
{
    using System.Linq;

    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public UsersService(IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.userRepository = userRepository;
        }

        public string GetUserEmailbyId(string userId)
        {
            var userEmail = this.userRepository
                .All()
                .Where(x => x.Id == userId)
                .Select(x => x.Email)
                .FirstOrDefault();

            return userEmail;
        }

        public string GetUserNameById(string userId)
        {
            var userName = this.userRepository
                .All()
                .Where(x => x.Id == userId)
                .Select(x => x.UserName)
                .FirstOrDefault();

            return userName;
        }
    }
}
