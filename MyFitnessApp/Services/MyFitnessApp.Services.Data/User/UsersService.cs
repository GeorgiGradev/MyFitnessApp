namespace MyFitnessApp.Services.Data.User
{
    using System.Collections.Generic;
    using System.Linq;

    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Data.Food;
    using MyFitnessApp.Services.Data.Profile;
    using MyFitnessApp.Services.Mapping;
    using MyFitnessApp.Web.ViewModels.Users;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IProfilesService profilesService;

        public UsersService(
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IFoodsService foodsService,
            IProfilesService profilesService)
        {
            this.usersRepository = userRepository;
            this.profilesService = profilesService;
        }

        public string GetUserEmailbyId(string userId)
        {
            var userEmail = this.usersRepository
                .All()
                .Where(x => x.Id == userId)
                .Select(x => x.Email)
                .FirstOrDefault();

            return userEmail;
        }

        public string GetUserNameById(string userId)
        {
            var userName = this.usersRepository
                .All()
                .Where(x => x.Id == userId)
                .Select(x => x.UserName)
                .FirstOrDefault();

            return userName;
        }

        public FoundUserViewModel SearchUserByUserName(string userName)
        {
            var user = this.usersRepository
                .All()
                .Where(x => x.UserName == userName)
                .To<FoundUserViewModel>()
                 .FirstOrDefault();

            return user;
        }

        public FoundUserViewModel SearchUserByEmail(string email)
        {
            var user = this.usersRepository
                .All()
                .Where(x => x.Email == email)
                .To<FoundUserViewModel>()
                .FirstOrDefault();

            return user;
        }

        public int GetCounts()
        {
            var totalUsersCount = this.usersRepository
                .All()
                .Count();

            return totalUsersCount;
        }
    }
}
