namespace MyFitnessApp.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Moq;
    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Data.Profile;
    using MyFitnessApp.Services.Data.User;
    using Xunit;

    public class UsersServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<ApplicationUser>> usersRepository;
        private readonly Mock<IDeletableEntityRepository<FollowerFollowee>> followerFolloweesRepository;
        private readonly Mock<IProfilesService> profilesService;

        public UsersServiceTests()
        {
            this.usersRepository = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            this.followerFolloweesRepository = new Mock<IDeletableEntityRepository<FollowerFollowee>>();
            this.profilesService = new Mock<IProfilesService>();
        }

        [Fact]
        public void GetUsernameByIdShouldReturnCorrectUsername()
        {
            var users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = new Profile(),
                },
            };

            this.usersRepository
                .Setup(x => x.All())
                .Returns(users
               .AsQueryable());

            var service = new UsersService(this.usersRepository.Object, this.followerFolloweesRepository.Object, this.profilesService.Object);
            var result = service.GetUserNameById("x123");
            Assert.Equal("vankata", result);

        }

        [Fact]
        public void GetEmailByIdShouldReturnCorrectEmail()
        {
            var users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = new Profile(),
                },
            };

            this.usersRepository
                .Setup(x => x.All())
                .Returns(users
               .AsQueryable());

            var service = new UsersService(this.usersRepository.Object, this.followerFolloweesRepository.Object, this.profilesService.Object);
            var result = service.GetUserEmailbyId("x123");
            Assert.Equal("ivan@ivan.bb", result);
        }

        [Fact]
        public void GetAllUsersCountShouldReturnCorrectValue()
        {
            var users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = new Profile(),
                },
                new ApplicationUser
                {
                Id = "y123",
                UserName = "petkata",
                Email = "petar@petrov.bb",
                FirstName = "Petar",
                LastName = "Petrov",
                Profile = new Profile(),
                },
            };

            this.usersRepository
                .Setup(x => x.All())
                .Returns(users
               .AsQueryable());

            var service = new UsersService(this.usersRepository.Object, this.followerFolloweesRepository.Object, this.profilesService.Object);
            var result = service.GetCounts();
            Assert.Equal(2, result);
        }
    }
}
