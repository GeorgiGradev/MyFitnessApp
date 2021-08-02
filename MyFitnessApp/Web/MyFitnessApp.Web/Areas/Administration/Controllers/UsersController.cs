namespace MyFitnessApp.Web.Areas.Administration.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.User;
    using MyFitnessApp.Web.ViewModels.Administration.Users;

    public class UsersController : AdministrationController
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
            this.usersService = usersService;
        }

        [HttpGet]
        public IActionResult All()
        {

            var users = this.usersService.GetAll();

            var viewModel = new ListAllUserViewModel()
            {
                AllUsers = users,
            };

            return this.View(viewModel);
        }
    }
}
