namespace MyFitnessApp.Services.Data.User
{
    using System.Collections.Generic;
    using System.Linq;

    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Data.Food;
    using MyFitnessApp.Services.Mapping;
    using MyFitnessApp.Web.ViewModels.Users;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public UsersService(
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IFoodsService foodsService)
        {
            this.usersRepository = userRepository;
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

        public IEnumerable<FoundUserViewModel> SearchUserByFirstName(string firstName)
        {
            var users = this.usersRepository
                .All()
                .Where(x => x.FirstName == firstName)
                .To<FoundUserViewModel>()
                .ToList();

            return users;
        }

        public IEnumerable<FoundUserViewModel> SearchUserByLastName(string lastName)
        {
            var users = this.usersRepository
                .All()
                .Where(x => x.LastName == lastName)
                .To<FoundUserViewModel>()
                .ToList();

            return users;
        }

        public IEnumerable<FoundUserViewModel> SearchUserByUserName(string userName)
        {
            var user = this.usersRepository
                .All()
                .Where(x => x.UserName == userName)
                .To<FoundUserViewModel>()
                 .ToList();

            return user;
        }

        public IEnumerable<FoundUserViewModel> SearchUserByEmail(string email)
        {
            var user = this.usersRepository
                .All()
                .Where(x => x.Email == email)
                .To<FoundUserViewModel>()
                 .ToList();

            return user;
        }
    }
}
