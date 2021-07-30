namespace MyFitnessApp.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.User;
    using MyFitnessApp.Web.ViewModels.Users;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IWebHostEnvironment environment;

        public UsersController(
            IUsersService usersService,
            IWebHostEnvironment environment)
        {
            this.usersService = usersService;
            this.environment = environment;
        }

        [HttpGet]
        [Authorize]
        public IActionResult CreateProfile()
        {
            var viewModel = new CreateProfileInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProfile(CreateProfileInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.GetId();

            try
            {
                await this.usersService.CreateProfileAsync(model, userId, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(model);
            }

            this.TempData["Message"] = "Profile created successfully.";

            return this.Redirect("/");
        }

        [HttpGet]
        [Authorize]
        public IActionResult MyProfile()
        {
            var userId = this.User.GetId();
            var viewModel = this.usersService.GetProfileData(userId);
            return this.View();
        }


        [HttpGet]
        [Authorize]
        public IActionResult MyGoals()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult MyGoals(MyGoalsInputModel model)
        {
            return this.View();
        }

        // Until here
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
            if (model.FirstName != null)
            {
                var users = this.usersService.SearchUserByFirstName(model.FirstName);

                var viewModel = new AllFoundUsersViewModel()
                {
                    FoundUsers = users,
                };

                return this.View("Found", viewModel);
            }
            else if (model.LastName != null)
            {
                var users = this.usersService.SearchUserByLastName(model.LastName);

                if (users.Count() == 0)
                {
                    return this.View();
                }

                var viewModel = new AllFoundUsersViewModel()
                {
                    FoundUsers = users,
                };

                return this.View("Found", viewModel);
            }
            else if (model.UserName != null)
            {
                var users = this.usersService.SearchUserByUserName(model.UserName);

                if (users.Count() == 0)
                {
                    return this.View();
                }

                var viewModel = new AllFoundUsersViewModel()
                {
                    FoundUsers = users,
                };

                return this.View("Found", viewModel);
            }
            else if (model.Email != null)
            {
                var users = this.usersService.SearchUserByEmail(model.Email);

                if (users.Count() == 0)
                {
                    return this.View();
                }

                var viewModel = new AllFoundUsersViewModel()
                {
                    FoundUsers = users,
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
