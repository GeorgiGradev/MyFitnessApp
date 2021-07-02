namespace MyFitnessApp.Web.Areas.Administration.Controllers
{
    using MyFitnessApp.Common;
    using MyFitnessApp.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
