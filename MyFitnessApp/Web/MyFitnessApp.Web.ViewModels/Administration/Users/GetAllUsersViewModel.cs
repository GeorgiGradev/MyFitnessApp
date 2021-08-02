namespace MyFitnessApp.Web.ViewModels.Administration.Users
{
    using System;

    public class GetAllUsersViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
