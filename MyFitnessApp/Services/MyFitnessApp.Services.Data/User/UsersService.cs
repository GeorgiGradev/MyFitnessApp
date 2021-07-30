namespace MyFitnessApp.Services.Data.User
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Mapping;
    using MyFitnessApp.Web.ViewModels.Users;

    public class UsersService : IUsersService
    {
        private readonly string[] allowedExtensions = new[] { "jpg" }; // позволени разширения
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<Profile> profileRepository;

        public UsersService(
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IDeletableEntityRepository<Profile> profileRepository)
        {
            this.userRepository = userRepository;
            this.profileRepository = profileRepository;
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
    }
}
