namespace MyFitnessApp.Services.Data.Tests
{
    using Microsoft.AspNetCore.Http;
    using Moq;
    using MyFitnessApp.Data;
    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Data.Repositories;
    using MyFitnessApp.Services.Data.Food;
    using MyFitnessApp.Services.Data.Profile;
    using MyFitnessApp.Web.ViewModels.Foods;
    using MyFitnessApp.Web.ViewModels.Profiles;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class ProfilesServiceTests : BaseServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<Profile>> profilesRepository;
        private readonly Mock<IDeletableEntityRepository<ApplicationUser>> usersRepository;
        private readonly Mock<IFoodsService> foodsService;

        public ProfilesServiceTests()
        {
            this.profilesRepository = new Mock<IDeletableEntityRepository<Profile>>();
            this.usersRepository = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            this.foodsService = new Mock<IFoodsService>();
        }

        [Fact]
        public void DoesUserHaveProfileShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var profilesRepository = new EfDeletableEntityRepository<Profile>(db);

            var service = new ProfilesService(profilesRepository, this.usersRepository.Object, this.foodsService.Object);

            var user = new ApplicationUser
            {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = null,
            };

            db.Users.Add(user);
            db.SaveChanges();

            var profile = new Profile
            {
                Gender = Gender.Female,
                ActivityLevel = ActivityLevel.Active,
                CurrentWeightInKg = 55,
                GoalWeightInKg = 50,
                HeightInCm = 170,
                NeckInCm = 34,
                WaistInCm = 60,
                HipsInCm = 90,
                DailyProteinIntakeGoal = 150,
                DailyCarbohydratesIntakeGoal = 150,
                DailyFatIntakeGoal = 40,
                AddedByUser = user,
                ImageUrl = "/images/profileimages/" + "1" + "." + "jpg",
                AboutMe = "I am the admin",
                MyInspirations = "To be healhty",
                WhyGetInShape = "To be the best looking girl",
            };

            db.Profiles.Add(profile);
            db.SaveChanges();

            var result = service.DoesUserHaveProfile(user.Id);

            Assert.True(result);
        }

        [Fact]
        public void GetUserIdByUserNameShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var usersRepository = new EfDeletableEntityRepository<ApplicationUser>(db);

            var service = new ProfilesService(this.profilesRepository.Object, usersRepository, this.foodsService.Object);

            var user = new ApplicationUser
            {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = null,
            };

            db.Users.Add(user);
            db.SaveChanges();

            var result = service.GetUserIdByUserName("vankata");

            Assert.Equal("x123", result);
        }

        [Fact]
        public void GetProfileIdByUserIdShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var profilesRepository = new EfDeletableEntityRepository<Profile>(db);

            var service = new ProfilesService(profilesRepository, this.usersRepository.Object, this.foodsService.Object);

            var user = new ApplicationUser
            {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = null,
            };

            db.Users.Add(user);
            db.SaveChanges();

            var profile = new Profile
            {
                Id = 1,
                Gender = Gender.Female,
                ActivityLevel = ActivityLevel.Active,
                CurrentWeightInKg = 55,
                GoalWeightInKg = 50,
                HeightInCm = 170,
                NeckInCm = 34,
                WaistInCm = 60,
                HipsInCm = 90,
                DailyProteinIntakeGoal = 150,
                DailyCarbohydratesIntakeGoal = 150,
                DailyFatIntakeGoal = 40,
                AddedByUser = user,
                ImageUrl = "/images/profileimages/" + "1" + "." + "jpg",
                AboutMe = "I am the admin",
                MyInspirations = "To be healhty",
                WhyGetInShape = "To be the best looking girl",
            };

            db.Profiles.Add(profile);
            db.SaveChanges();

            var result = service.GetPofileIdByUserId(user.Id);

            Assert.Equal(1, result);
        }

        [Fact]
        public void GetProfileDataForUpdate()
        {
            ApplicationDbContext db = GetDb();

            var profilesRepository = new EfDeletableEntityRepository<Profile>(db);

            var service = new ProfilesService(profilesRepository, this.usersRepository.Object, this.foodsService.Object);

            var user = new ApplicationUser
            {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = null,
            };

            db.Users.Add(user);
            db.SaveChanges();

            var profile = new Profile
            {
                Id = 1,
                Gender = Gender.Female,
                ActivityLevel = ActivityLevel.Active,
                CurrentWeightInKg = 55,
                GoalWeightInKg = 50,
                HeightInCm = 170,
                NeckInCm = 34,
                WaistInCm = 60,
                HipsInCm = 90,
                DailyProteinIntakeGoal = 150,
                DailyCarbohydratesIntakeGoal = 150,
                DailyFatIntakeGoal = 40,
                AddedByUser = user,
                ImageUrl = "/images/profileimages/" + "1" + "." + "jpg",
                AboutMe = "I am the admin",
                MyInspirations = "To be healhty",
                WhyGetInShape = "To be the best looking girl",
            };

            db.Profiles.Add(profile);
            db.SaveChanges();

            var result = service.GetProfileDataForUpdate(user.Id);

            Assert.Equal(profile.AboutMe, result.AboutMe);
            Assert.Equal(profile.WaistInCm, result.WaistInCm);
            Assert.Equal(profile.DailyFatIntakeGoal, result.DailyFatIntakeGoal);
        }

        [Fact]
        public async Task EditProfileAsyncShouldEditProfileCorrectly()
        {
            ApplicationDbContext db = GetDb();

            var profilesRepository = new EfDeletableEntityRepository<Profile>(db);
            var usersRepository = new EfDeletableEntityRepository<ApplicationUser>(db);

            var service = new ProfilesService(profilesRepository, usersRepository, this.foodsService.Object);

            var user = new ApplicationUser
            {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = null,
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var profile = new Profile
            {
                Id = 1,
                Gender = Gender.Female,
                ActivityLevel = ActivityLevel.Active,
                CurrentWeightInKg = 55,
                GoalWeightInKg = 50,
                HeightInCm = 170,
                NeckInCm = 34,
                WaistInCm = 60,
                HipsInCm = 90,
                DailyProteinIntakeGoal = 150,
                DailyCarbohydratesIntakeGoal = 150,
                DailyFatIntakeGoal = 40,
                AddedByUser = user,
                ImageUrl = "/images/profileimages/" + "1" + "." + "jpg",
                AboutMe = "I am the admin",
                MyInspirations = "To be healhty",
                WhyGetInShape = "To be the best looking girl",
            };

            await db.Profiles.AddAsync(profile);
            await db.SaveChangesAsync();

            var inputModel = new EditProfileInputModel
            {
                Username = "Strahil123",
                FirstName = "Strahil",
                LastName = "Strahilov",
                Email = "strahil@abv.bg",
                Gender = Gender.Female,
                ActivityLevel = ActivityLevel.Active,
                CurrentWeightInKg = 55,
                GoalWeightInKg = 50,
                HeightInCm = 170,
                NeckInCm = 34,
                WaistInCm = 60,
                HipsInCm = 90,
                DailyProteinIntakeGoal = 150,
                DailyCarbohydratesIntakeGoal = 150,
                DailyFatIntakeGoal = 40,
                AboutMe = "I am the admin",
                MyInspirations = "To be healhty",
                WhyGetInShape = "To be the best looking girl",
            };

            await service.EditProfileAsync(inputModel, user.Id);

            Assert.Equal(user.UserName, inputModel.Username);
        }
    }
}










//[Fact]
//public void GetProfileDataShouldReturnCorrectResult()
//{
//    ApplicationDbContext db = GetDb();

//    var profilesRepository = new EfDeletableEntityRepository<Profile>(db);
//    var usersRepository = new EfDeletableEntityRepository<ApplicationUser>(db);

//    var service = new ProfilesService(profilesRepository, usersRepository, this.foodsService.Object);

//    var user = new ApplicationUser
//    {
//        Id = "x123",
//        UserName = "vankata",
//        Email = "ivan@ivan.bb",
//        FirstName = "Ivan",
//        LastName = "Ivanov",
//        Profile = null,
//    };

//    db.Users.Add(user);
//    db.SaveChanges();

//    var profile = new Profile
//    {
//        Gender = Gender.Female,
//        ActivityLevel = ActivityLevel.Active,
//        CurrentWeightInKg = 55,
//        GoalWeightInKg = 50,
//        HeightInCm = 170,
//        NeckInCm = 34,
//        WaistInCm = 60,
//        HipsInCm = 90,
//        DailyProteinIntakeGoal = 150,
//        DailyCarbohydratesIntakeGoal = 150,
//        DailyFatIntakeGoal = 40,
//        AddedByUserId = user.Id,
//        ImageUrl = "/images/profileimages/" + "1" + "." + "jpg",
//        AboutMe = "I am the admin",
//        MyInspirations = "To be healhty",
//        WhyGetInShape = "To be the best looking girl",
//    };

//    db.Profiles.Add(profile);
//    db.SaveChanges();

//    var food = new Food
//    {
//        Id = 1,
//        Name = "Pork Fillet Grilled",
//        ProteinIn100Grams = 21,
//        CarbohydratesIn100Grams = 0,
//        FatIn100Grams = 8,
//        AddedByUserId = user.Id,
//    };

//    db.Foods.Add(food);
//    db.SaveChanges();

//    var meal = new Meal
//    {
//        Id = 1,
//        Name = MealName.Breakfast,
//        AddedByUserId = user.Id,
//    };

//    db.Meals.Add(meal);
//    db.SaveChanges();

//    var foodMeal = new FoodMeal
//    {
//        Id = 1,
//        FoodId = food.Id,
//        MealId = meal.Id,
//        ServingSizeInGrams = 100,
//    };

//    db.FoodMeals.Add(foodMeal);
//    db.SaveChanges();

//    var result = service.GetProfileData(user.Id);
//}




// [Fact]
// public async Task CreateProfileAsyncShouldCreateProfile()
// {
//    ApplicationDbContext db = GetDb();

// var profilesRepository = new EfDeletableEntityRepository<Profile>(db);

// var service = new ProfilesService(profilesRepository, this.usersRepository.Object, this.foodsService.Object);
//    var fileMock = new Mock<IFormFile>();

// var user = new ApplicationUser
//    {
//        Id = "x123",
//        UserName = "vankata",
//        Email = "ivan@ivan.bb",
//        FirstName = "Ivan",
//        LastName = "Ivanov",
//        Profile = null,
//    };

// await db.Users.AddAsync(user);
//    await db.SaveChangesAsync();

// // var imagePath = "C:\\Users\\G.Gradev\\Documents\\GitHub\\MyFitnessApp\\MyFitnessApp\\Web\\MyFitnessApp.Web\\wwwroot/images";
//    var imagePath = "wwwroot/images";

// var viewModel = new CreateProfileInputModel
//    {
//        Gender = Gender.Female,
//        ActivityLevel = ActivityLevel.Active,
//        CurrentWeightInKg = 55,
//        GoalWeightInKg = 50,
//        HeightInCm = 170,
//        NeckInCm = 34,
//        WaistInCm = 60,
//        HipsInCm = 90,
//        DailyProteinIntakeGoal = 150,
//        DailyCarbohydratesIntakeGoal = 150,
//        DailyFatIntakeGoal = 40,
//        AboutMe = "I am the admin",
//        MyInspirations = "To be healhty",
//        WhyGetInShape = "To be the best looking girl",
//        AddedByUserId = user.Id,
//        ImageUrl = fileMock.Object,
//    };
//    await service.CreateProfileAsync(viewModel, user.Id, imagePath);
//    var profiles = db.Profiles.Count();
//    ;
// }