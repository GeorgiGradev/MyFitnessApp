namespace MyFitnessApp.Services.Data.Tests
{
    using System;
    using System.Linq;

    using Moq;
    using MyFitnessApp.Data;
    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Data.Repositories;
    using MyFitnessApp.Services.Data.Profile;
    using MyFitnessApp.Services.Data.Search;
    using Xunit;

    public class SearchServiceTests : BaseServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<Food>> foodsRepository;
        private readonly Mock<IDeletableEntityRepository<Article>> articlesRepository;
        private readonly Mock<IDeletableEntityRepository<Exercise>> exercisesRepository;
        private readonly Mock<IDeletableEntityRepository<ApplicationUser>> usersRepository;
        private readonly Mock<IProfilesService> profilesService;

        public SearchServiceTests()
        {
            this.foodsRepository = new Mock<IDeletableEntityRepository<Food>>();
            this.articlesRepository = new Mock<IDeletableEntityRepository<Article>>();
            this.exercisesRepository = new Mock<IDeletableEntityRepository<Exercise>>();
            this.usersRepository = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            this.profilesService = new Mock<IProfilesService>();
        }

        [Fact]
        public void SearchFoodByKeyWordShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var foodsRepository = new EfDeletableEntityRepository<Food>(db);

            var service = new SearchService(foodsRepository, this.articlesRepository.Object, this.exercisesRepository.Object, this.usersRepository.Object, this.profilesService.Object);

            var food1 = new Food
            {
                Name = "Pork Fillet Grilled",
                ProteinIn100Grams = 21,
                CarbohydratesIn100Grams = 0,
                FatIn100Grams = 8,
            };

            var food2 = new Food
            {
                Name = "Olive Oil",
                ProteinIn100Grams = 0,
                CarbohydratesIn100Grams = 0,
                FatIn100Grams = 100,
            };

            db.Foods.Add(food1);
            db.Foods.Add(food2);
            db.SaveChanges();

            var result = service.SearchFoodByKeyword("Pork");

            var resultName = result.Where(x => x.Name == "Pork Fillet Grilled").FirstOrDefault().Name;

            Assert.Equal(food1.Name, resultName);
        }

        [Fact]
        public void SearchUserByUsernameShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var usersRepository = new EfDeletableEntityRepository<ApplicationUser>(db);

            var service = new SearchService(this.foodsRepository.Object, this.articlesRepository.Object, this.exercisesRepository.Object, usersRepository, this.profilesService.Object);

            var user = new ApplicationUser
            {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = new Profile(),
            };

            db.Users.Add(user);
            db.SaveChanges();

            var result = service.SearchUserByUsername("vankata");

            Assert.Equal(user.UserName, result.ToList().Where(x => x.UserName == "vankata").Select(x => x.UserName).FirstOrDefault());
            Assert.Equal(user.Id, result.ToList().Where(x => x.Id == "x123").Select(x => x.Id).FirstOrDefault());
            Assert.Equal(user.Email, result.ToList().Where(x => x.Email == "ivan@ivan.bb").Select(x => x.Email).FirstOrDefault());
            Assert.Equal(user.FirstName, result.ToList().Where(x => x.FirstName == "Ivan").Select(x => x.FirstName).FirstOrDefault());
            Assert.Equal(user.LastName, result.ToList().Where(x => x.LastName == "Ivanov").Select(x => x.LastName).FirstOrDefault());
        }

        [Fact]
        public void SearchUserByEmailShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var usersRepository = new EfDeletableEntityRepository<ApplicationUser>(db);

            var service = new SearchService(this.foodsRepository.Object, this.articlesRepository.Object, this.exercisesRepository.Object, usersRepository, this.profilesService.Object);

            var user = new ApplicationUser
            {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = new Profile(),
            };

            db.Users.Add(user);
            db.SaveChanges();

            var result = service.SearchUserByEmail("@ivan");

            Assert.Equal(user.UserName, result.ToList().Where(x => x.UserName == "vankata").Select(x => x.UserName).FirstOrDefault());
            Assert.Equal(user.Id, result.ToList().Where(x => x.Id == "x123").Select(x => x.Id).FirstOrDefault());
            Assert.Equal(user.Email, result.ToList().Where(x => x.Email == "ivan@ivan.bb").Select(x => x.Email).FirstOrDefault());
            Assert.Equal(user.FirstName, result.ToList().Where(x => x.FirstName == "Ivan").Select(x => x.FirstName).FirstOrDefault());
            Assert.Equal(user.LastName, result.ToList().Where(x => x.LastName == "Ivanov").Select(x => x.LastName).FirstOrDefault());
        }

        [Fact]
        public void SearcExerciseByKeywordShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var exercisesRepository = new EfDeletableEntityRepository<Exercise>(db);

            var service = new SearchService(this.foodsRepository.Object, this.articlesRepository.Object, exercisesRepository, this.usersRepository.Object, this.profilesService.Object);

            var exercise = new Exercise
            {
                Name = "Seated Arnold Press",
                Description = "Keep your back flat against the....",
                EquipmentId = 11,
                CategoryId = 1,
                Difficulty = Enum.Parse<ExerciseDifficulty>("Intermediate"),
                ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/seated-arnold-press-thumb.jpg",
                VideoUrl = "https://www.youtube.com/embed/hmnZKRpYaV8",
            };

            db.Exercises.Add(exercise);
            db.SaveChanges();

            var result = service.SearchExerciseByKeyword("press");

            Assert.Equal(exercise.Name, result.ToList().Where(x => x.Name == "Seated Arnold Press").Select(x => x.Name).FirstOrDefault());
        }

        [Fact]
        public void SearchArticleByKeyWordShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var articlesRepository = new EfDeletableEntityRepository<Article>(db);

            var service = new SearchService(this.foodsRepository.Object, articlesRepository, this.exercisesRepository.Object, this.usersRepository.Object, this.profilesService.Object);

            var article = new Article
            {
                Title = "Chocolate N’Ice Cream",
                Content = "Skip the dairy, fat and sugar — all with the magic of “nice cream.” The secret lies in the creamy sweetness of ripe bananas, frozen solid and then pureed. You’ll need a good blender and need to work quickly, so you can eat the nice cream while it has the texture of soft-serve. You can freeze the puree to eat later. Just spread it thinly in a storage tub so it softens evenly when you get it out to serve. The colder a food is, the harder it is to taste the sugar, so foods taste sweeter at room temperature than if they are frozen. That’s one of the reasons ice cream has so much sugar: It’s served cold, so it needs more sugar to taste sweet. All this to say, your “nice cream” will taste sweeter and creamier if it is lightly frozen, instead of totally frozen. Active time: 10 minutes Total time: 8 hours",
                Category = new ArticleCategory(),
                ImageUrl = "/images/articles/" + "1" + "." + "jpg",
            };

            db.Articles.Add(article);
            db.SaveChanges();

            var result = service.SearchArticleByKeyword("cream");

            var resultTitle = result.ToList().Where(x => x.Title == "Make-Ahead Instant Oatmeal Jars").FirstOrDefault().Title;

            Assert.Equal(article.Title, resultTitle);
        }
    }
}
