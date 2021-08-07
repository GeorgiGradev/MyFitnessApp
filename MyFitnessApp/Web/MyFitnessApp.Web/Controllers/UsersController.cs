namespace MyFitnessApp.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.Profile;
    using MyFitnessApp.Services.Data.User;
    using MyFitnessApp.Web.Filters;
    using MyFitnessApp.Web.ViewModels.Users;

    [Authorize]
    [TypeFilter(typeof(RestrictBannedUsersAttribute))]
    [TypeFilter(typeof(RestrictUsersWithoutProfileAttribute))]
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IProfilesService profilesService;

        public UsersController(
            IUsersService usersService,
            IProfilesService profilesService)
        {
            this.usersService = usersService;
            this.profilesService = profilesService;
        }

        [HttpPost]
        public async Task<IActionResult> Follow(string username)
        {
            var loggedUserId = this.User.GetId();
            var searchedUserId = this.profilesService.GetUserIdByUserName(username);
            await this.usersService.Follow(loggedUserId, searchedUserId);

            this.TempData["Message"] = $"Successfully followed {username}";
            return this.Redirect($"/Profiles/UsersProfile?username={username}");
        }

        [HttpPost]
        public async Task<IActionResult> Unfollow(string username)
        {
            var loggedUserId = this.User.GetId();
            var searchedUserId = this.profilesService.GetUserIdByUserName(username);
            await this.usersService.Unfollow(loggedUserId, searchedUserId);

            this.TempData["Message"] = @$"Successfully unfollowed {username}";
            return this.Redirect($"/Profiles/UsersProfile?username={username}");
        }

        [HttpGet]
        public IActionResult Followers()
        {
            var userId = this.User.GetId();
            var followers = this.usersService.GetFollowers(userId);
            var viewModel = new AllFollowerFolloweeViewModel()
            {
                FollowerFollowees = followers,
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Followees()
        {
            var userId = this.User.GetId();
            var followees = this.usersService.GetFollowees(userId);
            var viewModel = new AllFollowerFolloweeViewModel()
            {
                FollowerFollowees = followees,
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult All()
        {
            var users = this.usersService.All();
            var viewModel = new AllUsersViewModel()
            {
                Users = users,
            };

            return this.View(viewModel);
        }
    }
}
