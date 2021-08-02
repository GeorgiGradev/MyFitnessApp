namespace MyFitnessApp.Web.ViewModels.Administration.Users
{
    using System.Collections.Generic;

    public class ListAllUserViewModel
    {
        public IEnumerable<GetAllUsersViewModel> AllUsers { get; set; }
    }
}
