namespace MyFitnessApp.Web.ViewModels.Forum
{
    using System;

    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Mapping;

    public class PostInCategoryViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ShortContent =>
            this.Content.Length > 100
            ? this.Content?.Substring(0, 100) + "..."
            : this.Content;

        public string AddedByUserUserName { get; set; }

        public int CommentsCount { get; set; }
    }
}
