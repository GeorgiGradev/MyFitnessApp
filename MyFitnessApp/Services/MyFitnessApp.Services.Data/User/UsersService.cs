namespace MyFitnessApp.Services.Data.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Data.Profile;
    using MyFitnessApp.Services.Mapping;
    using MyFitnessApp.Web.ViewModels.Administration.Users;
    using MyFitnessApp.Web.ViewModels.Users;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<FollowerFollowee> followerFolloweesRepository;
        private readonly IProfilesService profilesService;

        public UsersService(
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IDeletableEntityRepository<FollowerFollowee> followerFolloweesRepository,
            IProfilesService profilesService)
        {
            this.usersRepository = userRepository;
            this.followerFolloweesRepository = followerFolloweesRepository;
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
                .Where(x => x.Profile != null && x.UserName != "admin")
                .Count();

            return totalUsersCount;
        }

        public IEnumerable<GetAllUsersViewModel> GetAll()
        {
            var viewModel = this.usersRepository
                .All()
                .Where(x => x.Profile != null && x.UserName != "admin")
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

        public async Task Follow(string followerId, string followeeId)
        {
            var followerFollowee = new FollowerFollowee()
            {
                FollowerId = followerId,
                FolloweeId = followeeId,
            };

            await this.followerFolloweesRepository.AddAsync(followerFollowee);
            await this.followerFolloweesRepository.SaveChangesAsync();
        }

        public async Task Unfollow(string followerId, string followeeId)
        {
            var followerFollowee = this.followerFolloweesRepository
                .All()
                .FirstOrDefault(x => x.FollowerId == followerId &&
                                      x.FolloweeId == followeeId);

            this.followerFolloweesRepository.HardDelete(followerFollowee);

            await this.followerFolloweesRepository.SaveChangesAsync();
        }

        public bool IsFollowee(string loggedUserId, string searchedUserId)
        {
            var isFollowee = this.followerFolloweesRepository
                .All()
                .Any(x => x.FollowerId == loggedUserId &&
                           x.FolloweeId == searchedUserId);

            return isFollowee;
        }

        public IEnumerable<FollowerFolloweeViewModel> GetFollowers(string userId)
        {
            var viewModel = this.followerFolloweesRepository
                .All()
                .Where(x => x.FolloweeId == userId)
                .Select(x => new FollowerFolloweeViewModel
                {
                    Id = x.FollowerId,
                    FirstName = x.Follower.FirstName,
                    LastName = x.Follower.LastName,
                    ImageUrl = "/images/profileimages/" + this.profilesService.GetPofileIdByUserId(x.FollowerId) + "." + "jpg",
                    Username = x.Follower.UserName,
                })
                .ToList();

            return viewModel;
        }

        public IEnumerable<FollowerFolloweeViewModel> GetFollowees(string userId)
        {
            var viewModel = this.followerFolloweesRepository
                .All()
                .Where(x => x.FollowerId == userId)
                .Select(x => new FollowerFolloweeViewModel
                {
                    Id = x.FolloweeId,
                    FirstName = x.Followee.FirstName,
                    LastName = x.Followee.LastName,
                    ImageUrl = "/images/profileimages/" + this.profilesService.GetPofileIdByUserId(x.FolloweeId) + "." + "jpg",
                    Username = x.Followee.UserName,
                })
                .ToList();

            return viewModel;
        }
    }
}
