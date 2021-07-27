namespace MyFitnessApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.User;
    using MyFitnessApp.Web.ViewModels.Users;
    using System.Linq;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
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
