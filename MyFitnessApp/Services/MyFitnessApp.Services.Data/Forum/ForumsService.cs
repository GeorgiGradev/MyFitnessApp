namespace MyFitnessApp.Services.Data.Forum
{
    using System.Collections.Generic;
    using System.Linq;

    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Mapping;
    using MyFitnessApp.Web.ViewModels.Forum;

    public class ForumsService : IForumsService
    {
        private readonly IDeletableEntityRepository<ForumCategory> forumCategoryRepository;

        public ForumsService(IDeletableEntityRepository<ForumCategory> forumCategoryRepository)
        {
            this.forumCategoryRepository = forumCategoryRepository;
        }

        public IEnumerable<CategoryViewModel> GetAllCategories()
        {
            var viewModel = this.forumCategoryRepository
                .All()
                .To<CategoryViewModel>()
                .ToList();

            return viewModel;
        }

        public CategoryViewModel GetCategoryByName(string name)
        {
            var viewModel = this.forumCategoryRepository
                .All()
                .Where(x => x.Name.Replace(" ", "-") == name.Replace(" ", "-"))
                .To<CategoryViewModel>()
                .FirstOrDefault();

            return viewModel;
        }
    }
}