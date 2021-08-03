namespace MyFitnessApp.Services.Data.Profile
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Data.Food;
    using MyFitnessApp.Web.ViewModels.Profiles;

    public class ProfilesService : IProfilesService
    {
        private readonly string[] allowedExtensions = new[] { "jpg" }; // позволени разширения
        private readonly IDeletableEntityRepository<Profile> profileRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IFoodsService foodsService;

        public ProfilesService(
            IDeletableEntityRepository<Profile> profileRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IFoodsService foodsService)
        {
            this.profileRepository = profileRepository;
            this.usersRepository = usersRepository;
            this.foodsService = foodsService;
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

            // записваме картинката като комбинация от Id на Article и extension (123.jpeg)
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

            var user = this.usersRepository
                .All()
                .Where(x => x.Id == userId)
                .FirstOrDefault();

            user.ProfileId = profile.Id;
            await this.usersRepository.SaveChangesAsync();
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
            var userName = this.usersRepository
                .All()
                .Where(x => x.Id == userId)
                .Select(x => x.UserName)
                .FirstOrDefault();
            var firstName = this.usersRepository
                .All()
                .Where(x => x.Id == userId)
                .Select(x => x.FirstName)
                .FirstOrDefault();
            var lastName = this.usersRepository
                .All()
                .Where(x => x.Id == userId)
                .Select(x => x.LastName)
                .FirstOrDefault();
            var memberSince = this.usersRepository
                .All()
                .Where(x => x.Id == userId)
                .Select(x => x.CreatedOn)
                .FirstOrDefault()
                .ToString("dddd, dd MMMM yyyy");
            var email = this.usersRepository
                .All()
                .Where(x => x.Id == userId)
                .Select(x => x.Email)
                .FirstOrDefault();

            var foodDiaryCalories = this.foodsService.GetFoodDiary(userId);
            var totalFOodDiaryCalories =
                foodDiaryCalories.Breakfast.Sum(x => x.TotalCalories)
                + foodDiaryCalories.Lunch.Sum(x => x.TotalCalories)
                + foodDiaryCalories.Snack.Sum(x => x.TotalCalories)
                + foodDiaryCalories.Dinner.Sum(x => x.TotalCalories);

            var internalImagePath = this.GetInternalImagePath(userId);

            var viewModel = this.profileRepository
                .All()
                .Where(x => x.AddedByUserId == userId)
                .Select(x => new ProfileViewModel
                {
                    UserId = userId,
                    Username = userName,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    MemberSince = memberSince,
                    Gender = x.Gender.ToString(),
                    ActivityLevel = x.ActivityLevel.ToString(),
                    ImageUrl = internalImagePath,
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

            return viewModel;
        }

        public string GetInternalImagePath(string userId)
        {
            var imagePath = this.profileRepository
            .All()
            .Where(x => x.AddedByUserId == userId)
            .Select(x => x.ImageUrl)
            .FirstOrDefault();

            var internalImagePath = string.Empty;

            if (imagePath != string.Empty)
            {
                var splittedPath = imagePath.Split("wwwroot").ToList();
                internalImagePath = splittedPath[1];
            }

            return internalImagePath;
        }

        public string GetUserIdByUserName(string userName)
        {
            var userId = this.usersRepository
                .All()
                .Where(x => x.UserName == userName)
                .Select(x => x.Id)
                .FirstOrDefault();

            return userId;
        }

        public async Task EditProfileAsync(EditProfileInputModel model, string userId)
        {
            var userProfile = this.profileRepository
                .All()
                .FirstOrDefault(x => x.AddedByUserId == userId);

            var user = this.usersRepository
                .All()
                .FirstOrDefault(x => x.Id == userId);

            userProfile.Gender = model.Gender;
            userProfile.ActivityLevel = model.ActivityLevel;
            userProfile.CurrentWeightInKg = model.CurrentWeightInKg;
            userProfile.GoalWeightInKg = model.GoalWeightInKg;
            userProfile.HeightInCm = model.HeightInCm;
            userProfile.NeckInCm = model.NeckInCm;
            userProfile.WaistInCm = model.WaistInCm;
            userProfile.HipsInCm = model.HipsInCm;
            userProfile.DailyProteinIntakeGoal = model.DailyProteinIntakeGoal;
            userProfile.DailyCarbohydratesIntakeGoal = model.DailyCarbohydratesIntakeGoal;
            userProfile.DailyFatIntakeGoal = model.DailyFatIntakeGoal;
            userProfile.AboutMe = model.AboutMe;
            userProfile.WhyGetInShape = model.WhyGetInShape;
            userProfile.MyInspirations = model.MyInspirations;

            await this.profileRepository.SaveChangesAsync();

            user.UserName = model.Username;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;

            await this.usersRepository.SaveChangesAsync();
        }

        public EditProfileInputModel GetProfileDataForUpdate(string userId)
        {
            var userName = this.usersRepository
                .All()
                .Where(x => x.Id == userId)
                .Select(x => x.UserName)
                .FirstOrDefault();
            var firstName = this.usersRepository
                .All()
                .Where(x => x.Id == userId)
                .Select(x => x.FirstName)
                .FirstOrDefault();
            var lastName = this.usersRepository
                .All()
                .Where(x => x.Id == userId)
                .Select(x => x.LastName)
                .FirstOrDefault();
            var email = this.usersRepository
                .All()
                .Where(x => x.Id == userId)
                .Select(x => x.Email)
                .FirstOrDefault();

            var internalImagePath = this.GetInternalImagePath(userId);

            var viewModel = this.profileRepository
                .All()
                .Where(x => x.AddedByUserId == userId)
                .Select(x => new EditProfileInputModel
                {
                    Username = userName,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Gender = x.Gender,
                    ActivityLevel = x.ActivityLevel,
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
                })
                .FirstOrDefault();

            return viewModel;
        }

        public async Task EditProfileImageAsync(EditProfileImageInputModel model, string userId, string imagePath)
        {
            var userProfile = this.profileRepository
                .All()
                .FirstOrDefault(x => x.AddedByUserId == userId);

            Directory.CreateDirectory($"{imagePath}/profileimages/");
            var profileId = userProfile.Id;
            var extension = Path.GetExtension(model.ImageUrl.FileName).TrimStart('.');
            if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
            {
                throw new Exception($"Invalid image extension {extension}");
            }

            var physicalPath = $"{imagePath}/profileimages/{profileId}.{extension}";
            using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
            await model.ImageUrl.CopyToAsync(fileStream);
            userProfile.ImageUrl = physicalPath;
            await this.profileRepository.SaveChangesAsync();
        }
    }
}
