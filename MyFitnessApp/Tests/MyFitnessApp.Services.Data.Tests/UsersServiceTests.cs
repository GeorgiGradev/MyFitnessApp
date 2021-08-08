namespace MyFitnessApp.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Moq;
    using MyFitnessApp.Data;
    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Data.Repositories;
    using MyFitnessApp.Services.Data.Profile;
    using MyFitnessApp.Services.Data.User;
    using MyFitnessApp.Web.ViewModels.Administration.Users;
    using Xunit;

    public class UsersServiceTests : BaseServiceTests
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

        [Fact]
        public void IsUserBannedShouldReturnCorrectResult()
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
                IsBanned = true,
                },
            };

            this.usersRepository
                .Setup(x => x.All())
                .Returns(users
               .AsQueryable());

            var service = new UsersService(this.usersRepository.Object, this.followerFolloweesRepository.Object, this.profilesService.Object);
            var result = service.IsUserBanned("x123");
            Assert.True(result);
        }

        [Fact]
        public void IsUserFolloweeShouldReturnCorrectResult()
        {
            var user1 = new ApplicationUser
            {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = new Profile(),
                Followees = new List<FollowerFollowee>
                {
                     new FollowerFollowee
                     {
                         Id = 1,
                         FollowerId = "x123",
                         FolloweeId = "y123",
                     },
                },
            };

            var user2 = new ApplicationUser
            {
                Id = "y123",
                UserName = "petkata",
                Email = "petar@petar.bb",
                FirstName = "Petar",
                LastName = "Petrov",
                Profile = new Profile(),
            };

            var users = new List<ApplicationUser>
            {
                user1,
                user2,
            };

            var followerFollowee1 = new FollowerFollowee
            {
                Id = 1,
                FolloweeId = "y123",
                FollowerId = "x123",
            };

            var followerFollowees = new List<FollowerFollowee>
            {
                followerFollowee1,
            };

            this.usersRepository
                .Setup(x => x.All())
                .Returns(users
                .AsQueryable());

            this.followerFolloweesRepository
                .Setup(x => x.All())
                .Returns(followerFollowees
                .AsQueryable());

            var service = new UsersService(this.usersRepository.Object, this.followerFolloweesRepository.Object, this.profilesService.Object);
            Assert.True(service.IsFollowee("x123", "y123"));
        }

        [Fact]
        public void GetAllUsersViewModelsShouldReturnCorrectResult()
        {
            var user1 = new ApplicationUser
            {
                Id = "x123",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "ivan@ivanov.com",
                UserName = "vankata",
                CreatedOn = DateTime.UtcNow,
                IsBanned = false,
                BannedOn = null,
                Profile = new Profile(),
            };

            var user2 = new ApplicationUser
            {
                Id = "y123",
                FirstName = "Petar",
                LastName = "Petrov",
                Email = "petar@petrov.com",
                UserName = "petkata",
                CreatedOn = DateTime.UtcNow,
                IsBanned = false,
                Profile = new Profile(),
            };

            var user3 = new ApplicationUser
            {
                Id = "z123",
                FirstName = "Todor",
                LastName = "Todorov",
                Email = "todor@todorov.com",
                UserName = "toshkata",
                CreatedOn = DateTime.UtcNow,
                IsBanned = false,
                BannedOn = null,
                Profile = new Profile(),
            };

            var users = new List<ApplicationUser>
            {
                user1,
                user2,
                user3,
            };

            this.usersRepository
                .Setup(x => x.All())
                .Returns(users
                .AsQueryable());

            var service = new UsersService(this.usersRepository.Object, this.followerFolloweesRepository.Object, this.profilesService.Object);
            var result = service.GetAll();
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void AllUsersViewModelsShouldReturnCorrectResult()
        {
            var user1 = new ApplicationUser
            {
                Id = "x123",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "ivan@ivanov.com",
                UserName = "vankata",
                CreatedOn = DateTime.UtcNow,
                IsBanned = false,
                BannedOn = null,
                Profile = new Profile(),
            };

            var user2 = new ApplicationUser
            {
                Id = "y123",
                FirstName = "Petar",
                LastName = "Petrov",
                Email = "petar@petrov.com",
                UserName = "petkata",
                CreatedOn = DateTime.UtcNow,
                IsBanned = false,
                Profile = new Profile(),
            };

            var user3 = new ApplicationUser
            {
                Id = "z123",
                FirstName = "Todor",
                LastName = "Todorov",
                Email = "todor@todorov.com",
                UserName = "toshkata",
                CreatedOn = DateTime.UtcNow,
                IsBanned = false,
                BannedOn = null,
                Profile = new Profile(),
            };

            var users = new List<ApplicationUser>
            {
                user1,
                user2,
                user3,
            };

            this.usersRepository
                .Setup(x => x.All())
                .Returns(users
                .AsQueryable());

            var service = new UsersService(this.usersRepository.Object, this.followerFolloweesRepository.Object, this.profilesService.Object);
            var result = service.All();
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void BanMethodShouldBanUser()
        {
            var user = new ApplicationUser
            {
                Id = "x123",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "ivan@ivanov.com",
                UserName = "vankata",
                CreatedOn = DateTime.UtcNow,
                IsBanned = false,
                BannedOn = null,
                Profile = new Profile(),
            };

            var users = new List<ApplicationUser>
            {
                user,
            };

            this.usersRepository
                 .Setup(x => x.All())
                 .Returns(users
                 .AsQueryable());

            var service = new UsersService(this.usersRepository.Object, this.followerFolloweesRepository.Object, this.profilesService.Object);

            var viewModel = new BanUserInputModel
            {
                BanReason = "Bad bahavior",
            };

            var result = service.Ban(viewModel, user.Id);

            Assert.True(user.IsBanned == true);
        }

        [Fact]
        public void UnBanMethodShouldUnBanUser()
        {
            var user = new ApplicationUser
            {
                Id = "x123",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "ivan@ivanov.com",
                UserName = "vankata",
                CreatedOn = DateTime.UtcNow,
                IsBanned = true,
                BannedOn = null,
                Profile = new Profile(),
            };

            var users = new List<ApplicationUser>
            {
                user,
            };

            this.usersRepository
                 .Setup(x => x.All())
                 .Returns(users
                 .AsQueryable());

            var service = new UsersService(this.usersRepository.Object, this.followerFolloweesRepository.Object, this.profilesService.Object);

            var result = service.Unban(user.Id);

            Assert.True(user.IsBanned == false);
        }

        [Fact]
        public async Task FollowMethodShouldFollowUser()
        {
            ApplicationDbContext db = GetDb();

            var usersRepository = new EfDeletableEntityRepository<ApplicationUser>(db);
            var followerFolloweesRepository = new EfDeletableEntityRepository<FollowerFollowee>(db);

            var service = new UsersService(usersRepository, followerFolloweesRepository, this.profilesService.Object);

            var user1 = new ApplicationUser
            {
                Id = "x123",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "ivan@ivanov.com",
                UserName = "vankata",
                CreatedOn = DateTime.UtcNow,
                IsBanned = false,
                Profile = new Profile(),
            };

            var user2 = new ApplicationUser
            {
                Id = "y123",
                FirstName = "Petar",
                LastName = "Petrov",
                Email = "petar@petrov.com",
                UserName = "petkata",
                CreatedOn = DateTime.UtcNow,
                IsBanned = false,
                Profile = new Profile(),
            };

            await db.Users.AddAsync(user1);
            await db.Users.AddAsync(user2);
            await db.SaveChangesAsync();

            await service.Follow(user1.Id, user2.Id);

            var result = user1.Followers.Count;

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task UnfollowMethodShouldUnfollowUser()
        {
            ApplicationDbContext db = GetDb();

            var usersRepository = new EfDeletableEntityRepository<ApplicationUser>(db);
            var followerFolloweesRepository = new EfDeletableEntityRepository<FollowerFollowee>(db);

            var service = new UsersService(usersRepository, followerFolloweesRepository, this.profilesService.Object);

            var user1 = new ApplicationUser
            {
                Id = "x123",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "ivan@ivanov.com",
                UserName = "vankata",
                CreatedOn = DateTime.UtcNow,
                IsBanned = false,
                Profile = new Profile(),
            };

            var user2 = new ApplicationUser
            {
                Id = "y123",
                FirstName = "Petar",
                LastName = "Petrov",
                Email = "petar@petrov.com",
                UserName = "petkata",
                CreatedOn = DateTime.UtcNow,
                IsBanned = false,
                Profile = new Profile(),
            };

            await db.Users.AddAsync(user1);
            await db.Users.AddAsync(user2);
            await db.SaveChangesAsync();

            var followerFollowee = new FollowerFollowee
            {
                FollowerId = user1.Id,
                FolloweeId = user2.Id,
            };

            await db.FollowerFollowees.AddAsync(followerFollowee);
            await db.SaveChangesAsync();

            await service.Unfollow(user1.Id, user2.Id);

            var result = user1.Followers.Count;

            Assert.Equal(0, result);
        }

        [Fact]
        public void GetFollowersShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var usersRepository = new EfDeletableEntityRepository<ApplicationUser>(db);
            var followerFolloweesRepository = new EfDeletableEntityRepository<FollowerFollowee>(db);

            var service = new UsersService(usersRepository, followerFolloweesRepository, this.profilesService.Object);

            var user1 = new ApplicationUser
            {
                Id = "x123",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "ivan@ivanov.com",
                UserName = "vankata",
                CreatedOn = DateTime.UtcNow,
                IsBanned = false,
                BannedOn = null,
                Profile = new Profile(),
            };

            var user2 = new ApplicationUser
            {
                Id = "y123",
                FirstName = "Petar",
                LastName = "Petrov",
                Email = "petar@petrov.com",
                UserName = "petkata",
                CreatedOn = DateTime.UtcNow,
                IsBanned = false,
                Profile = new Profile(),
            };

            var user3 = new ApplicationUser
            {
                Id = "z123",
                FirstName = "Todor",
                LastName = "Todorov",
                Email = "todor@todorov.com",
                UserName = "toshkata",
                CreatedOn = DateTime.UtcNow,
                IsBanned = false,
                BannedOn = null,
                Profile = new Profile(),
            };

            db.Users.Add(user1);
            db.Users.Add(user2);
            db.Users.Add(user3);
            db.SaveChanges();

            var followerFollowee1 = new FollowerFollowee
            {
                FollowerId = user2.Id,
                FolloweeId = user1.Id,
            };

            var followerFollowee2 = new FollowerFollowee
            {
                FollowerId = user3.Id,
                FolloweeId = user1.Id,
            };

            db.FollowerFollowees.Add(followerFollowee1);
            db.FollowerFollowees.Add(followerFollowee2);
            db.SaveChanges();

            var result = service.GetFollowers(user1.Id).Count();

            Assert.Equal(2, result);
        }

        [Fact]
        public void GetFolloweesShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var usersRepository = new EfDeletableEntityRepository<ApplicationUser>(db);
            var followerFolloweesRepository = new EfDeletableEntityRepository<FollowerFollowee>(db);

            var service = new UsersService(usersRepository, followerFolloweesRepository, this.profilesService.Object);

            var user1 = new ApplicationUser
            {
                Id = "x123",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "ivan@ivanov.com",
                UserName = "vankata",
                CreatedOn = DateTime.UtcNow,
                IsBanned = false,
                BannedOn = null,
                Profile = new Profile(),
            };

            var user2 = new ApplicationUser
            {
                Id = "y123",
                FirstName = "Petar",
                LastName = "Petrov",
                Email = "petar@petrov.com",
                UserName = "petkata",
                CreatedOn = DateTime.UtcNow,
                IsBanned = false,
                Profile = new Profile(),
            };

            var user3 = new ApplicationUser
            {
                Id = "z123",
                FirstName = "Todor",
                LastName = "Todorov",
                Email = "todor@todorov.com",
                UserName = "toshkata",
                CreatedOn = DateTime.UtcNow,
                IsBanned = false,
                BannedOn = null,
                Profile = new Profile(),
            };

            db.Users.Add(user1);
            db.Users.Add(user2);
            db.Users.Add(user3);
            db.SaveChanges();

            var followerFollowee1 = new FollowerFollowee
            {
                FollowerId = user1.Id,
                FolloweeId = user2.Id,
            };

            var followerFollowee2 = new FollowerFollowee
            {
                FollowerId = user1.Id,
                FolloweeId = user3.Id,
            };

            db.FollowerFollowees.Add(followerFollowee1);
            db.FollowerFollowees.Add(followerFollowee2);
            db.SaveChanges();

            var result = service.GetFollowees(user1.Id).Count();

            Assert.Equal(2, result);
        }
    }
}
