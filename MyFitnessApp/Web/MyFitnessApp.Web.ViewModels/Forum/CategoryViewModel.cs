namespace MyFitnessApp.Web.ViewModels.Forum
{
    using System.Collections.Generic;

    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Mapping;

    public class CategoryViewModel : IMapFrom<ForumCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<PostInCategoryViewModel> Posts { get; set; }

        public string Url => $"/Forums/ByName/{this.Name.Replace(' ', '-')}";
    }
}
