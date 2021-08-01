namespace MyFitnessApp.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.Profile;
    using MyFitnessApp.Services.Data.User;
    using MyFitnessApp.Web.ViewModels.Users;

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

        [HttpGet]
        [Authorize]
        public IActionResult Search()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Search(SearchUserInputModel model)
        {
            if (model.UserName != null)
            {
                var user = this.usersService.SearchUserByUserName(model.UserName);

                var viewModel = new FoundUserViewModel()
                {
                   FirstName = user.FirstName,
                   LastName = user.LastName,
                   Email = user.Email,
                   UserName = user.UserName,
                   Id = user.Id,
                   UserProfileImage = this.profilesService.GetInternalImagePath(user.Id),
                };

                return this.View("Found", viewModel);
            }
            else if (model.Email != null)
            {
                var user = this.usersService.SearchUserByEmail(model.Email);

                var viewModel = new FoundUserViewModel()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.UserName,
                    Id = user.Id,
                    UserProfileImage = this.profilesService.GetInternalImagePath(user.Id),
                };

                return this.View("Found", viewModel);
            }
            else
            {
                return this.View();
            }
        }

        public IActionResult Found()
        {
            return this.View();
        }
    }
}
