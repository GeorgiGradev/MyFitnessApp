namespace MyFitnessApp.Web.ViewModels.Forum
{
    using System.Collections.Generic;

    using MyFitnessApp.Data.Models;

    public class CategoryViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}
