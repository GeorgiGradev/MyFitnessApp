namespace MyFitnessApp.Web.ViewModels.Posts
{
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Mapping;

    public class CategoryViewModel : IMapFrom<ForumCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
