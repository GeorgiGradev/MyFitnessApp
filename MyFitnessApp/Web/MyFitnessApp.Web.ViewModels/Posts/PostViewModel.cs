namespace MyFitnessApp.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;

    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Mapping;
    using MyFitnessApp.Web.ViewModels.Comments;

    public class PostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AddedByUserUserName { get; set; }

        public DateTime AddedByUserCreatedOn { get; set; }

        public string AddedByUserId { get; set; }

        public string CategoryName { get; set; }

        public string UserProfileImage { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
