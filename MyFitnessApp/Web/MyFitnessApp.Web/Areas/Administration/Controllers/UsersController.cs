namespace MyFitnessApp.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

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

        [HttpGet]
        public IActionResult Ban()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Ban(BanUserInputModel input, string id)
        {
            await this.usersService.Ban(input, id);
            return this.Redirect("/Administration/Users/All");
        }

        [HttpPost]
        public async Task<IActionResult> Unban(string id)
        {
            await this.usersService.Unban(id);
            return this.Redirect("/Administration/Users/All");
        }
    }
}
