namespace MyFitnessApp.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.Profile;
    using MyFitnessApp.Web.Filters;
    using MyFitnessApp.Web.ViewModels.Profiles;

    [Authorize]
    [TypeFilter(typeof(RestrictBannedUsersAttribute))]
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
        public IActionResult CreateProfile()
        {
            var viewModel = new CreateProfileInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
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

            return this.RedirectToAction("MyProfile", "Profiles");
        }

        [HttpGet]
        public IActionResult MyProfile()
        {
            var userId = this.User.GetId();
            var viewModel = this.profilesService.GetProfileData(userId);
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult MyGoals()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult UsersProfile(string userName)
        {
            var userId = this.profilesService.GetUserIdByUserName(userName);

            var viewModel = this.profilesService.GetProfileData(userId);
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            var userId = this.User.GetId();
            var viewModel = this.profilesService.GetProfileDataForUpdate(userId);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(EditProfileInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.GetId();

            await this.profilesService.EditProfileAsync(model, userId);

            this.TempData["Message"] = "Profile updated successfully.";

            return this.RedirectToAction("MyProfile", "Profiles");
        }

        [HttpGet]
        public IActionResult EditProfileImage()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> EditProfileImage(EditProfileImageInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var userId = this.User.GetId();

            await this.profilesService.EditProfileImageAsync(model, userId, $"{this.environment.WebRootPath}/images");

            this.TempData["Message"] = "Profile image updated successfully.";

            return this.RedirectToAction("MyProfile", "Profiles");
        }
    }
}
