namespace MyFitnessApp.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.Article;
    using MyFitnessApp.Services.Data.Exercise;
    using MyFitnessApp.Services.Data.Food;
    using MyFitnessApp.Services.Data.Post;
    using MyFitnessApp.Services.Data.User;
    using MyFitnessApp.Web.ViewModels.Administration.Dashboard;

    public class DashboardController : AdministrationController
    {
        private readonly IUsersService usersService;
        private readonly IArticlesService articlesService;
        private readonly IExercisesService exercisesService;
        private readonly IPostsService postService;
        private readonly IFoodsService foodsService;

        public DashboardController(
            IUsersService usersService,
            IArticlesService articlesService,
            IExercisesService exercisesService,
            IPostsService postService,
            IFoodsService foodsService)
        {
            this.usersService = usersService;
            this.articlesService = articlesService;
            this.exercisesService = exercisesService;
            this.postService = postService;
            this.foodsService = foodsService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel()
            {
                UsersCount = this.usersService.GetCounts(),
                ArticlesCount = this.articlesService.GetCounts(),
                FoodsCount = this.foodsService.GetCounts(),
                PostsCount = this.postService.GetCounts(),
                ExercisesCount = this.exercisesService.GetCounts(),
            };

            return this.View(viewModel);
        }
    }
}
