namespace MyFitnessApp.Services.Data.User
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Data.Food;
    using MyFitnessApp.Services.Mapping;
    using MyFitnessApp.Web.ViewModels.Users;

    public class UsersService : IUsersService
    {
        private readonly string[] allowedExtensions = new[] { "jpg" }; // позволени разширения
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<Profile> profileRepository;
        private readonly IFoodsService foodsService;

        public UsersService(
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IDeletableEntityRepository<Profile> profileRepository,
            IFoodsService foodsService)
        {
            this.userRepository = userRepository;
            this.profileRepository = profileRepository;
            this.foodsService = foodsService;
        }

        public string GetUserEmailbyId(string userId)
        {
            var userEmail = this.userRepository
                .All()
                .Where(x => x.Id == userId)
                .Select(x => x.Email)
                .FirstOrDefault();

            return userEmail;
        }

        public string GetUserNameById(string userId)
        {
            var userName = this.userRepository
                .All()
                .Where(x => x.Id == userId)
                .Select(x => x.UserName)
                .FirstOrDefault();

            return userName;
        }

        public IEnumerable<FoundUserViewModel> SearchUserByFirstName(string firstName)
        {
            var users = this.userRepository
                .All()
                .Where(x => x.FirstName == firstName)
                .To<FoundUserViewModel>()
                .ToList();

            return users;
        }

        public IEnumerable<FoundUserViewModel> SearchUserByLastName(string lastName)
        {
            var users = this.userRepository
                .All()
                .Where(x => x.LastName == lastName)
                .To<FoundUserViewModel>()
                .ToList();

            return users;
        }

        public IEnumerable<FoundUserViewModel> SearchUserByUserName(string userName)
        {
            var user = this.userRepository
                .All()
                .Where(x => x.UserName == userName)
                .To<FoundUserViewModel>()
                 .ToList();

            return user;
        }

        public IEnumerable<FoundUserViewModel> SearchUserByEmail(string email)
        {
            var user = this.userRepository
                .All()
                .Where(x => x.Email == email)
                .To<FoundUserViewModel>()
                 .ToList();

            return user;
        }

        public async Task CreateProfileAsync(CreateProfileInputModel model, string userId, string imagePath)
        {
            var profile = new Profile
            {
                Gender = model.Gender,
                ActivityLevel = model.ActivityLevel,
                CurrentWeightInKg = model.CurrentWeightInKg,
                GoalWeightInKg = model.GoalWeightInKg,
                HeightInCm = model.HeightInCm,
                NeckInCm = model.NeckInCm,
                WaistInCm = model.WaistInCm,
                HipsInCm = model.HipsInCm,
                DailyProteinIntakeGoal = model.DailyProteinIntakeGoal,
                DailyCarbohydratesIntakeGoal = model.DailyCarbohydratesIntakeGoal,
                DailyFatIntakeGoal = model.DailyFatIntakeGoal,
                AboutMe = model.AboutMe,
                WhyGetInShape = model.WhyGetInShape,
                MyInspirations = model.MyInspirations,
                AddedByUserId = userId,
            };

            await this.profileRepository.AddAsync(profile);
            await this.profileRepository.SaveChangesAsync();

            Directory.CreateDirectory($"{imagePath}/profileimages/");

            var profileId = profile.Id;
            var extension = Path.GetExtension(model.ImageUrl.FileName).TrimStart('.');

            if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
            {
                throw new Exception($"Invalid image extension {extension}");
            }

            var physicalPath = $"{imagePath}/profileimages/{profileId}.{extension}";
            using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
            await model.ImageUrl.CopyToAsync(fileStream);

            profile.ImageUrl = physicalPath;
            await this.profileRepository.SaveChangesAsync();

            // записваме картинката като комбинация от Id на Article и extension (123.jpeg)
        }

        public bool DoesUserHaveProfile(string userId)
        {
            bool doesUserHaveProfile = this.profileRepository
                .All()
                .Any(x => x.AddedByUserId == userId);

            return doesUserHaveProfile;
        }

        public ProfileViewModel GetProfileData(string userId)
        {
            var userName = this.userRepository
                .All()
                .Where(x => x.Id == userId)
                .Select(x => x.UserName)
                .FirstOrDefault();
            var firstName = this.userRepository
                .All()
                .Where(x => x.Id == userId)
                .Select(x => x.FirstName)
                .FirstOrDefault();
            var lastName = this.userRepository
                .All()
                .Where(x => x.Id == userId)
                .Select(x => x.LastName)
                .FirstOrDefault();
            var memberSince = this.userRepository
                .All()
                .Where(x => x.Id == userId)
                .Select(x => x.CreatedOn)
                .FirstOrDefault()
                .ToString("dddd, dd MMMM yyyy");

            var foodDiaryCalories = this.foodsService.GetFoodDiary(userId);
            var totalFOodDiaryCalories =
                foodDiaryCalories.Breakfast.Sum(x => x.TotalCalories)
                + foodDiaryCalories.Lunch.Sum(x => x.TotalCalories)
                + foodDiaryCalories.Snack.Sum(x => x.TotalCalories)
                + foodDiaryCalories.Dinner.Sum(x => x.TotalCalories);

            var imagePath = this.profileRepository
                .All()
                .Where(x => x.AddedByUserId == userId)
                .Select(x => x.ImageUrl)
                .FirstOrDefault();

            var applicationImagePath = string.Empty;

            if (imagePath != string.Empty)
            {
                var splittedPath = imagePath.Split("wwwroot").ToList();
                applicationImagePath = splittedPath[1];
            }

            var viewModel = this.profileRepository
                .All()
                .Where(x => x.AddedByUserId == userId)
                .Select(x => new ProfileViewModel
                {
                    Username = userName,
                    FirstName = firstName,
                    LastName = lastName,
                    MemberSince = memberSince,
                    Gender = x.Gender.ToString(),
                    ActivityLevel = x.ActivityLevel.ToString(),
                    ImageUrl = applicationImagePath,
                    CurrentWeightInKg = x.CurrentWeightInKg,
                    GoalWeightInKg = x.GoalWeightInKg,
                    HeightInCm = x.HeightInCm,
                    NeckInCm = x.NeckInCm,
                    WaistInCm = x.WaistInCm,
                    HipsInCm = x.HipsInCm,
                    DailyProteinIntakeGoal = x.DailyProteinIntakeGoal,
                    DailyCarbohydratesIntakeGoal = x.DailyCarbohydratesIntakeGoal,
                    DailyFatIntakeGoal = x.DailyFatIntakeGoal,
                    AboutMe = x.AboutMe,
                    WhyGetInShape = x.WhyGetInShape,
                    MyInspirations = x.MyInspirations,
                    DailyCaloriesIntakeGoal = (x.DailyProteinIntakeGoal * 4) + (x.DailyCarbohydratesIntakeGoal * 4) + (x.DailyFatIntakeGoal * 9),
                    FoodDiaryCalories = totalFOodDiaryCalories,
                    CaloriesIntakeDifference = totalFOodDiaryCalories - (x.DailyProteinIntakeGoal * 4) + (x.DailyCarbohydratesIntakeGoal * 4) + (x.DailyFatIntakeGoal * 9),
                })
                .FirstOrDefault();
            // /images/profileimages/4.jpg
            return viewModel;
        }
    }
}
