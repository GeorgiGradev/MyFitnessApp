namespace MyFitnessApp.Web.ViewModels.Users
{
    using System.Collections.Generic;

    public class AllFollowerFolloweeViewModel
    {
        public IEnumerable<FollowerFolloweeViewModel> FollowerFollowees { get; set; }
    }
}
