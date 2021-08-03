namespace MyFitnessApp.Services.Data.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Data.Food;
    using MyFitnessApp.Services.Data.Profile;
    using MyFitnessApp.Services.Mapping;
    using MyFitnessApp.Web.ViewModels.Administration.Users;
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
                .Where(x => x.ProfileId != 0 && x.UserName != "admin")
                .Count();

            return totalUsersCount;
        }

        public IEnumerable<GetAllUsersViewModel> GetAll()
        {
            var viewModel = this.usersRepository
                .All()
                .Where(x => x.ProfileId != 0 && x.UserName != "admin")
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .Select(x => new GetAllUsersViewModel
                {
                     FirstName = x.FirstName,
                     LastName = x.LastName,
                     Email = x.Email,
                     Username = x.UserName,
                     CreatedOn =x.CreatedOn,
                     Id = x.Id,
                     IsBanned = x.IsBanned,
                     BannedOn = x.BannedOn,
                })
                .ToList();

            return viewModel;
        }

        public async Task Ban(BanUserInputModel model, string userId)
        {
            var user = this.usersRepository
                    .All()
                    .FirstOrDefault(x => x.Id == userId);

            user.IsBanned = true;
            user.BannedOn = DateTime.UtcNow;
            user.BanReason = model.BanReason;

            this.usersRepository.Update(user);
            await this.usersRepository.SaveChangesAsync();
        }

        public async Task Unban(string userId)
        {
            var user = this.usersRepository
                    .All()
                    .FirstOrDefault(x => x.Id == userId);

            user.IsBanned = false;
            user.BannedOn = null;
            user.BanReason = null;

            this.usersRepository.Update(user);
            await this.usersRepository.SaveChangesAsync();
        }

        public bool IsUserBanned(string userId)
        {
            bool isUserBanned = this.usersRepository
                .All()
                .Where(x => x.Id == userId)
                .Any(x => x.IsBanned == true);

            return isUserBanned;
        }
    }
}
