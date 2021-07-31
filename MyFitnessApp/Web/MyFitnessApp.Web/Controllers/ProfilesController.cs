namespace MyFitnessApp.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.Profile;
    using MyFitnessApp.Web.ViewModels.Profiles;

    public class ProfilesController : Controller
    {
        private readonly IProfilesService profilesService;
        private readonly IWebHostEnvironment environment;

        public ProfilesController(
            IProfilesService profilesService,
            IWebHostEnvironment environment)
        {
            this.profilesService = profilesService;
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
                await this.profilesService.CreateProfileAsync(model, userId, $"{this.environment.WebRootPath}/images");
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
            var viewModel = this.profilesService.GetProfileData(userId);
            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult MyGoals()
        {
            return this.View();
        }
    }
}
