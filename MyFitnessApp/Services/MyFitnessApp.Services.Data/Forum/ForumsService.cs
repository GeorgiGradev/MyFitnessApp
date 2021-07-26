namespace MyFitnessApp.Services.Data.Forum
{
    using System.Collections.Generic;
    using System.Linq;

    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
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
                .Select(x => new CategoryViewModel
                {
                    Name = x.Name,
                    Description = x.Description,
                    Posts = x.Posts,
                })
                .ToList();

            return viewModel;
        }
    }
}
