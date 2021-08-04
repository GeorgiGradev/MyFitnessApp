namespace MyFitnessApp.Web.Filters
{
    using System;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Routing;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Data.Profile;

    public class RestrictUsersWithoutProfileAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IProfilesService profilesService;
        private readonly UserManager<ApplicationUser> userManager;

        public RestrictUsersWithoutProfileAttribute(
            IProfilesService profilesService,
            UserManager<ApplicationUser> userManager)
        {
            this.profilesService = profilesService;
            this.userManager = userManager;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string userId = this.userManager.GetUserId(context.HttpContext.User);

            bool doesUserHaveProfile = this.profilesService.DoesUserHaveProfile(userId);

            if (doesUserHaveProfile == false)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new
                    {
                        action = "NoProfile",
                        controller = "Errors",
                    }));
            }
        }
    }
}
