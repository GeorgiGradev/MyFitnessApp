namespace MyFitnessApp.Web.ViewModels.Comments
{
    using System;

    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string AddedByUserUserName { get; set; }

        public string AddedByUserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime AddedByUserCreatedOn { get; set; }
    }
}
