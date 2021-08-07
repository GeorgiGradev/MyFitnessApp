namespace MyFitnessApp.Services.Data.Search
{
    using System.Collections.Generic;
    using System.Linq;

    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Data.Profile;
    using MyFitnessApp.Web.ViewModels.Search;

    public class SearchService : ISearchService
    {
        private readonly IDeletableEntityRepository<Food> foodsRepository;
        private readonly IDeletableEntityRepository<Article> articlesRepository;
        private readonly IDeletableEntityRepository<Exercise> exercisesRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IProfilesService profilesService;

        public SearchService(
            IDeletableEntityRepository<Food> foodsRepository,
            IDeletableEntityRepository<Article> articlesRepository,
            IDeletableEntityRepository<Exercise> exercisesRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IProfilesService profilesService)
        {
            this.foodsRepository = foodsRepository;
            this.articlesRepository = articlesRepository;
            this.exercisesRepository = exercisesRepository;
            this.usersRepository = usersRepository;
            this.profilesService = profilesService;
        }

        public IEnumerable<FoodViewModel> SearchFoodByKeyword(string keyword)
        {
            var foods = this.foodsRepository
                .All()
                .Where(x => x.Name.Contains(keyword))
                .Select(x => new FoodViewModel
                {
                    Name = x.Name,
                    ProteinIn100Grams = x.ProteinIn100Grams,
                    CarbohydratesIn100Grams = x.CarbohydratesIn100Grams,
                    FatIn100Grams = x.FatIn100Grams,
                    TotalCalories = (x.ProteinIn100Grams * 4) + (x.CarbohydratesIn100Grams * 4) + (x.FatIn100Grams * 9),
                    CreatedOn = x.CreatedOn,
                })
                .ToList();

            return foods;
        }

        public IEnumerable<ArticleViewModel> SearchArticleByKeyword(string keyword)
        {
            var articles = this.articlesRepository
               .All()
               .Where(x => x.Title.Contains(keyword))
            .Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
                ImagePath = "/images/articles/" + x.Id + "." + "jpg",
                UserId = x.AddedByUserId,
                CreatedOn = x.CreatedOn.ToString("f"),
                Username = x.AddedByUser.UserName,
            })
            .ToList();

            return articles;
        }

        public IEnumerable<ExerciseViewModel> SearchExerciseByKeyword(string keyword)
        {
            var exercises = this.exercisesRepository
               .All()
               .Where(x => x.Name.Contains(keyword) || x.Category.Name.Contains(keyword))
            .Select(x => new ExerciseViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
                ImageUrl = x.ImageUrl,
                VideoUrl = x.VideoUrl,
                EquipmentId = x.EquipmentId,
                EquipmentName = x.Equipment.Name,
                DifficultyName = x.Difficulty.ToString(),
            })
            .ToList();

            return exercises;
        }

        public IEnumerable<UserViewModel> SearchUserByUsername(string username)
        {
            var users = this.usersRepository
                .All()
                .Where(x => x.UserName.Contains(username) && x.Profile != null)
                .Select(x => new UserViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    UserName = x.UserName,
                    UserProfileImage = "/images/profileimages/" + this.profilesService.GetPofileIdByUserId(x.Id) + "." + "jpg",
                })
                .ToList();

            return users;
        }

        public IEnumerable<UserViewModel> SearchUserByEmail(string email)
        {
            var users = this.usersRepository
                .All()
                .Where(x => x.Email.Contains(email) && x.Profile != null)
                .Select(x => new UserViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    UserName = x.UserName,
                    UserProfileImage = "/images/profileimages/" + this.profilesService.GetPofileIdByUserId(x.Id) + "." + "jpg",
                })
                .ToList();

            return users;
        }
    }
}
