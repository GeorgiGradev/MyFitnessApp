namespace MyFitnessApp.Web.Filters
{
    using System;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Routing;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Data.User;

    public class RestrictBannedUsersAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IUsersService usersService;
        private readonly UserManager<ApplicationUser> userManager;

        public RestrictBannedUsersAttribute(
            IUsersService usersService,
            UserManager<ApplicationUser> userManager)
        {
            this.usersService = usersService;
            this.userManager = userManager;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string userId = this.userManager.GetUserId(context.HttpContext.User);

            bool isUserBanned = this.usersService.IsUserBanned(userId);

            if (isUserBanned)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new
                    {
                        action = "RestrictedAccess",
                        controller = "Errors",
                    }));
            }
        }
    }
}
