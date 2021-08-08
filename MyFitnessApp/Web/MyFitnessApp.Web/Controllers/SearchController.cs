namespace MyFitnessApp.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.Search;
    using MyFitnessApp.Web.Filters;
    using MyFitnessApp.Web.ViewModels.Search;

    [Authorize]
    [TypeFilter(typeof(RestrictBannedUsersAttribute))]
    [TypeFilter(typeof(RestrictUsersWithoutProfileAttribute))]
    public class SearchController : Controller
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet]
        public IActionResult SearchFood()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult SearchFood(FoodInputModel model)
        {
            var foods = this.searchService.SearchFoodByKeyword(model.Keyword);
            if (foods.Count() != 0)
            {
                var viewModel = new AllFoodsViewModel
                {
                    Foods = foods,
                };
                return this.View("FoundFood", viewModel);
            }
            else
            {
                this.TempData["Message"] = "There was no food found with the given keyword.";
                return this.View();
            }
        }

        [HttpGet]
        public IActionResult SearchArticle()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult SearchArticle(ArticleInputModel model)
        {
            var articles = this.searchService.SearchArticleByKeyword(model.Keyword);
            if (articles.Count() != 0)
            {
                var viewModel = new AllArticlesViewModel
                {
                    Articles = articles,
                };
                return this.View("FoundArticle", viewModel);
            }
            else
            {
                this.TempData["Message"] = "There was no article title found with the given keyword.";
                return this.View();
            }
        }

        [HttpGet]
        public IActionResult SearchExercise()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult SearchExercise(ExerciseInputModel model)
        {
            var exercises = this.searchService.SearchExerciseByKeyword(model.Keyword);
            if (exercises.Count() != 0)
            {
                var viewModel = new AllExercisesViewModel
                {
                    Exercises = exercises,
                };
                return this.View("FoundExercise", viewModel);
            }
            else
            {
                this.TempData["Message"] = "There was no exercise found with the given keyword.";
                return this.View();
            }
        }

        [HttpGet]
        public IActionResult SearchUser()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult SearchUser(UserInputModel model)
        {
            if (model.UserName != null)
            {
                var username = model.UserName;
                var users = this.searchService.SearchUserByUsername(username);

                if (users.Count() == 0)
                {
                    this.TempData["Message"] = "There was no user found with the given username.";
                    return this.View();
                }

                var viewModel = new AllUsersViewModel()
                {
                    Users = users,
                };

                return this.View("FoundUser", viewModel);
            }
            else if (model.Email != null)
            {
                if (model.Email != null)
                {
                    var email = model.Email;
                    var users = this.searchService.SearchUserByEmail(email);

                    if (users.Count() == 0)
                    {
                        this.TempData["Message"] = "There was no user found with the given email.";
                        return this.View();
                    }

                    var viewModel = new AllUsersViewModel()
                    {
                        Users = users,
                    };

                    return this.View("FoundUser", viewModel);
                }
            }

            return this.View();
        }
    }
}
