namespace MyFitnessApp.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Moq;
    using MyFitnessApp.Data;
    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Data.Repositories;
    using MyFitnessApp.Services.Data.Exercise;
    using MyFitnessApp.Services.Mapping;
    using MyFitnessApp.Web.ViewModels.Exercises;
    using Xunit;

    public class ExercisesServicesTests : BaseServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<ExerciseCategory>> exerciseCategoryRepository;
        private readonly Mock<IDeletableEntityRepository<ExerciseEquipment>> exerciseEquipmentRepository;
        private readonly Mock<IDeletableEntityRepository<Exercise>> exerciseRepository;
        private readonly Mock<IDeletableEntityRepository<UserExercise>> userExerciseRepository;

        public ExercisesServicesTests()
        {
            this.exerciseCategoryRepository = new Mock<IDeletableEntityRepository<ExerciseCategory>>();
            this.exerciseEquipmentRepository = new Mock<IDeletableEntityRepository<ExerciseEquipment>>();
            this.exerciseRepository = new Mock<IDeletableEntityRepository<Exercise>>();
            this.userExerciseRepository = new Mock<IDeletableEntityRepository<UserExercise>>();
        }

        // using Mock
        [Fact]
        public void MockGetExerciseCategoriesShouldReturnAllCategories()
        {
            var category1 = new ExerciseCategory
            {
                Name = "Biceps",
            };

            var category2 = new ExerciseCategory
            {
                Name = "Triceps",
            };

            var category3 = new ExerciseCategory
            {
                Name = "Back",
            };

            var category4 = new ExerciseCategory
            {
                Name = "Abs",
            };

            var categories = new List<ExerciseCategory>
            {
                category1,
                category2,
                category3,
                category4,
            };

            this.exerciseCategoryRepository
                .Setup(x => x.AllAsNoTracking())
                .Returns(categories
               .AsQueryable());

            var service = new ExercisesService(this.exerciseCategoryRepository.Object, this.exerciseEquipmentRepository.Object, this.exerciseRepository.Object, this.userExerciseRepository.Object);

            var result = service.GetExerciseCategories();

            Assert.Equal(4, result.Count());
            Assert.NotNull(result.Where(x => x.Name == category1.Name).FirstOrDefault());
            Assert.NotNull(result.Where(x => x.Name == category2.Name).FirstOrDefault());
            Assert.NotNull(result.Where(x => x.Name == category3.Name).FirstOrDefault());
            Assert.NotNull(result.Where(x => x.Name == category4.Name).FirstOrDefault());
            Assert.Null(result.Where(x => x.Name == "Something").FirstOrDefault());
        }

        // using InMemoryDatabase
        [Fact]
        public void GetExerciseCategoriesShouldReturnAllCategories()
        {
            ApplicationDbContext db = GetDb();

            var exerciseCategoryRepository = new EfDeletableEntityRepository<ExerciseCategory>(db);
            var exerciseEquipmentRepository = new EfDeletableEntityRepository<ExerciseEquipment>(db);
            var exerciseRepository = new EfDeletableEntityRepository<Exercise>(db);
            var userExerciseRepository = new EfDeletableEntityRepository<UserExercise>(db);

            var service = new ExercisesService(exerciseCategoryRepository, exerciseEquipmentRepository, exerciseRepository, userExerciseRepository);

            var category1 = new ExerciseCategory
            {
                Name = "Biceps",
            };

            var category2 = new ExerciseCategory
            {
                Name = "Triceps",
            };

            var category3 = new ExerciseCategory
            {
                Name = "Back",
            };

            var category4 = new ExerciseCategory
            {
                Name = "Abs",
            };

            db.ExerciseCategories.Add(category1);
            db.ExerciseCategories.Add(category2);
            db.ExerciseCategories.Add(category3);
            db.ExerciseCategories.Add(category4);
            db.SaveChanges();

            var result = service.GetExerciseCategories();

            Assert.Equal(4, result.Count());
            Assert.NotNull(result.Where(x => x.Name == category1.Name).FirstOrDefault());
            Assert.NotNull(result.Where(x => x.Name == category2.Name).FirstOrDefault());
            Assert.NotNull(result.Where(x => x.Name == category3.Name).FirstOrDefault());
            Assert.NotNull(result.Where(x => x.Name == category4.Name).FirstOrDefault());
            Assert.Null(result.Where(x => x.Name == "Something").FirstOrDefault());
        }

        [Fact]
        public void GetExercisEquipmentsShouldReturnAllEquipments()
        {
            var equipment1 = new ExerciseEquipment
            {
                Name = "Dumbbell",
            };

            var equipment2 = new ExerciseEquipment
            {
                Name = "Barbell",
            };

            var equipment3 = new ExerciseEquipment
            {
                Name = "Rope",
            };

            var equipments = new List<ExerciseEquipment>
            {
                equipment1,
                equipment2,
                equipment3,
            };

            this.exerciseEquipmentRepository
                .Setup(x => x.All())
                .Returns(equipments
               .AsQueryable());

            var service = new ExercisesService(this.exerciseCategoryRepository.Object, this.exerciseEquipmentRepository.Object, this.exerciseRepository.Object, this.userExerciseRepository.Object);

            var result = service.GetExerciseEquipments();

            Assert.Equal(3, result.Count());
            Assert.NotNull(result.Where(x => x.Name == equipment1.Name).FirstOrDefault());
            Assert.NotNull(result.Where(x => x.Name == equipment2.Name).FirstOrDefault());
            Assert.NotNull(result.Where(x => x.Name == equipment3.Name).FirstOrDefault());
            Assert.Null(result.Where(x => x.Name == "Something").FirstOrDefault());
        }

        [Fact]
        public void GetEmbedYouTubeLink()
        {
            ApplicationDbContext db = GetDb();

            var exerciseCategoryRepository = new EfDeletableEntityRepository<ExerciseCategory>(db);
            var exerciseEquipmentRepository = new EfDeletableEntityRepository<ExerciseEquipment>(db);
            var exerciseRepository = new EfDeletableEntityRepository<Exercise>(db);
            var userExerciseRepository = new EfDeletableEntityRepository<UserExercise>(db);

            var service = new ExercisesService(exerciseCategoryRepository, exerciseEquipmentRepository, exerciseRepository, userExerciseRepository);

            var rawYouTubeLink = "https://www.youtube.com/watch?v=jv31A4Ab4nA";

            var result = service.GetEmbedYouTubeLink(rawYouTubeLink);
            var expectedResult = "https://www.youtube.com/embed/jv31A4Ab4nA";

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task CreateExerciseShouldCreateExercice()
        {
            {
                ApplicationDbContext db = GetDb();

                var exerciseCategoryRepository = new EfDeletableEntityRepository<ExerciseCategory>(db);
                var exerciseEquipmentRepository = new EfDeletableEntityRepository<ExerciseEquipment>(db);
                var exerciseRepository = new EfDeletableEntityRepository<Exercise>(db);
                var userExerciseRepository = new EfDeletableEntityRepository<UserExercise>(db);

                var service = new ExercisesService(exerciseCategoryRepository, exerciseEquipmentRepository, exerciseRepository, userExerciseRepository);

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

                var equipment = new ExerciseEquipment
                {
                    Id = 1,
                    Name = "Dumbbell",
                };

                await db.ExerciseEquipments.AddAsync(equipment);
                await db.SaveChangesAsync();

                var category = new ExerciseCategory
                {
                    Id = 1,
                    Name = "Biceps",
                };

                await db.ExerciseCategories.AddAsync(category);
                await db.SaveChangesAsync();

                var inputModel = new CreateExerciseInputModel
                {
                    Name = "Seated Arnold Press",
                    Description = "Keep your back flat against ....",
                    EquipmentId = 1,
                    CategoryId = 1,
                    Difficulty = ExerciseDifficulty.Expert,
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/seated-arnold-press-thumb.jpg",
                    VideoUrl = "https://www.youtube.com/watch?v=jv31A4Ab4nA",
                };

                await service.CreateExcerciseAsync(inputModel, user.Id);

                var result = db.Exercises
                    .Where(x => x.Name == "Seated Arnold Press")
                    .FirstOrDefault();

                Assert.Equal(inputModel.Name, result.Name);
            }
        }

        [Fact]
        public async Task GetAllExercisesShouldReturnAllExercises()
        {
            ApplicationDbContext db = GetDb();

            var exerciseCategoryRepository = new EfDeletableEntityRepository<ExerciseCategory>(db);
            var exerciseEquipmentRepository = new EfDeletableEntityRepository<ExerciseEquipment>(db);
            var exerciseRepository = new EfDeletableEntityRepository<Exercise>(db);
            var userExerciseRepository = new EfDeletableEntityRepository<UserExercise>(db);

            var service = new ExercisesService(exerciseCategoryRepository, exerciseEquipmentRepository, exerciseRepository, userExerciseRepository);

            AutoMapperConfig.RegisterMappings(typeof(ExerciseViewModel).Assembly, typeof(Exercise).Assembly);

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

            var equipment = new ExerciseEquipment
            {
                Id = 1,
                Name = "Dumbbell",
            };

            await db.ExerciseEquipments.AddAsync(equipment);
            await db.SaveChangesAsync();

            var category = new ExerciseCategory
            {
                Id = 1,
                Name = "Biceps",
            };

            await db.ExerciseCategories.AddAsync(category);
            await db.SaveChangesAsync();

            var inputModel1 = new CreateExerciseInputModel
            {
                Name = "Seated Arnold Press",
                Description = "Keep your back flat against ....",
                EquipmentId = 1,
                CategoryId = 1,
                Difficulty = ExerciseDifficulty.Expert,
                ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/seated-arnold-press-thumb.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=jv31A4Ab4nA",
            };
            await service.CreateExcerciseAsync(inputModel1, user.Id);

            var inputModel2 = new CreateExerciseInputModel
            {
                Name = "Pull ups",
                Description = "Pull ups description....",
                EquipmentId = 1,
                CategoryId = 1,
                Difficulty = ExerciseDifficulty.Beginner,
                ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/seated-arnold-press-thumb.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=jv31A4Ab4nA",
            };
            await service.CreateExcerciseAsync(inputModel2, user.Id);

            var result = service.GetAllExercises(1, 2);

            Assert.Equal(2, result.Count());
            Assert.True(inputModel1.Name == result.Where(x => x.Name == "Seated Arnold Press").Select(x => x.Name).FirstOrDefault());
            Assert.True(inputModel2.Description == result.Where(x => x.Description == "Pull ups description....").Select(x => x.Description).FirstOrDefault());
        }

        [Fact]
        public async Task GetCountsShouldReturnCorrectResult()
        {
            ApplicationDbContext db = GetDb();

            var exerciseCategoryRepository = new EfDeletableEntityRepository<ExerciseCategory>(db);
            var exerciseEquipmentRepository = new EfDeletableEntityRepository<ExerciseEquipment>(db);
            var exerciseRepository = new EfDeletableEntityRepository<Exercise>(db);
            var userExerciseRepository = new EfDeletableEntityRepository<UserExercise>(db);

            var service = new ExercisesService(exerciseCategoryRepository, exerciseEquipmentRepository, exerciseRepository, userExerciseRepository);

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

            var equipment = new ExerciseEquipment
            {
                Id = 1,
                Name = "Dumbbell",
            };

            await db.ExerciseEquipments.AddAsync(equipment);
            await db.SaveChangesAsync();

            var category = new ExerciseCategory
            {
                Id = 1,
                Name = "Biceps",
            };

            await db.ExerciseCategories.AddAsync(category);
            await db.SaveChangesAsync();

            var inputModel1 = new CreateExerciseInputModel
            {
                Name = "Seated Arnold Press",
                Description = "Keep your back flat against ....",
                EquipmentId = 1,
                CategoryId = 1,
                Difficulty = ExerciseDifficulty.Expert,
                ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/seated-arnold-press-thumb.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=jv31A4Ab4nA",
            };
            await service.CreateExcerciseAsync(inputModel1, user.Id);

            var inputModel2 = new CreateExerciseInputModel
            {
                Name = "Pull ups",
                Description = "Pull ups description....",
                EquipmentId = 1,
                CategoryId = 1,
                Difficulty = ExerciseDifficulty.Beginner,
                ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/seated-arnold-press-thumb.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=jv31A4Ab4nA",
            };
            await service.CreateExcerciseAsync(inputModel2, user.Id);

            var result = service.GetCounts();

            Assert.Equal(2, result);
        }

        [Fact]
        public async Task GetExerciseByIdShouldReturnCorrectExercise()
        {
            ApplicationDbContext db = GetDb();

            var exerciseCategoryRepository = new EfDeletableEntityRepository<ExerciseCategory>(db);
            var exerciseEquipmentRepository = new EfDeletableEntityRepository<ExerciseEquipment>(db);
            var exerciseRepository = new EfDeletableEntityRepository<Exercise>(db);
            var userExerciseRepository = new EfDeletableEntityRepository<UserExercise>(db);

            var service = new ExercisesService(exerciseCategoryRepository, exerciseEquipmentRepository, exerciseRepository, userExerciseRepository);

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

            var equipment = new ExerciseEquipment
            {
                Id = 1,
                Name = "Dumbbell",
            };

            await db.ExerciseEquipments.AddAsync(equipment);
            await db.SaveChangesAsync();

            var category = new ExerciseCategory
            {
                Id = 1,
                Name = "Biceps",
            };

            await db.ExerciseCategories.AddAsync(category);
            await db.SaveChangesAsync();

            var inputModel1 = new CreateExerciseInputModel
            {
                Name = "Seated Arnold Press",
                Description = "Keep your back flat against ....",
                EquipmentId = 1,
                CategoryId = 1,
                Difficulty = ExerciseDifficulty.Expert,
                ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/seated-arnold-press-thumb.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=jv31A4Ab4nA",
            };
            await service.CreateExcerciseAsync(inputModel1, user.Id);

            var inputModel2 = new CreateExerciseInputModel
            {
                Name = "Pull ups",
                Description = "Pull ups description....",
                EquipmentId = 1,
                CategoryId = 1,
                Difficulty = ExerciseDifficulty.Beginner,
                ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/seated-arnold-press-thumb.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=jv31A4Ab4nA",
            };
            await service.CreateExcerciseAsync(inputModel2, user.Id);

            var result = service.GetExerciseById(1);

            Assert.Equal(inputModel1.Name, result.Name);
            Assert.NotEqual(inputModel2.Name, result.Name);
        }

        [Fact]
        public async Task AddExerciseToUserShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDb();

            var exerciseCategoryRepository = new EfDeletableEntityRepository<ExerciseCategory>(db);
            var exerciseEquipmentRepository = new EfDeletableEntityRepository<ExerciseEquipment>(db);
            var exerciseRepository = new EfDeletableEntityRepository<Exercise>(db);
            var userExerciseRepository = new EfDeletableEntityRepository<UserExercise>(db);

            var service = new ExercisesService(exerciseCategoryRepository, exerciseEquipmentRepository, exerciseRepository, userExerciseRepository);

            var user1 = new ApplicationUser
            {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = null,
            };

            await db.Users.AddAsync(user1);
            await db.SaveChangesAsync();

            var user2 = new ApplicationUser
            {
                Id = "y123",
                UserName = "petkata",
                Email = "petar@petrov.bb",
                FirstName = "Petar",
                LastName = "Petrov",
                Profile = new Profile(),
            };

            await db.Users.AddAsync(user2);
            await db.SaveChangesAsync();

            var equipment = new ExerciseEquipment
            {
                Id = 1,
                Name = "Dumbbell",
            };

            await db.ExerciseEquipments.AddAsync(equipment);
            await db.SaveChangesAsync();

            var category = new ExerciseCategory
            {
                Id = 1,
                Name = "Biceps",
            };

            await db.ExerciseCategories.AddAsync(category);
            await db.SaveChangesAsync();

            var inputModel1 = new CreateExerciseInputModel
            {
                Name = "Seated Arnold Press",
                Description = "Keep your back flat against ....",
                EquipmentId = 1,
                CategoryId = 1,
                Difficulty = ExerciseDifficulty.Expert,
                ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/seated-arnold-press-thumb.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=jv31A4Ab4nA",
            };
            await service.CreateExcerciseAsync(inputModel1, user1.Id);

            var inputModel2 = new CreateExerciseInputModel
            {
                Name = "Pull ups",
                Description = "Pull ups description....",
                EquipmentId = 1,
                CategoryId = 1,
                Difficulty = ExerciseDifficulty.Beginner,
                ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/seated-arnold-press-thumb.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=jv31A4Ab4nA",
            };
            await service.CreateExcerciseAsync(inputModel2, user1.Id);

            var inputModel = new AddExerciseInputModel
            {
                Id = 2,
                Repetitions = 10,
                Sets = 5,
                Weight = 20,
                WeekDay = WeekDay.Monday,
            };

            await service.AddExerciseToUserAsync(inputModel, user2.Id);

            var result = db.UserExercises.Where(x => x.UserId == user2.Id).Select(x => x.Exercise.Name).FirstOrDefault();

            Assert.Equal(inputModel2.Name, result);
            Assert.NotEqual(inputModel1.Name, result);
        }

        [Fact]
        public async Task GetExerciseByCategoryIdShouldWorkCorrectl()
        {
            ApplicationDbContext db = GetDb();

            var exerciseCategoryRepository = new EfDeletableEntityRepository<ExerciseCategory>(db);
            var exerciseEquipmentRepository = new EfDeletableEntityRepository<ExerciseEquipment>(db);
            var exerciseRepository = new EfDeletableEntityRepository<Exercise>(db);
            var userExerciseRepository = new EfDeletableEntityRepository<UserExercise>(db);

            var service = new ExercisesService(exerciseCategoryRepository, exerciseEquipmentRepository, exerciseRepository, userExerciseRepository);

            AutoMapperConfig.RegisterMappings(typeof(ExerciseViewModel).Assembly, typeof(Exercise).Assembly);

            var user1 = new ApplicationUser
            {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = null,
            };

            await db.Users.AddAsync(user1);
            await db.SaveChangesAsync();

            var equipment = new ExerciseEquipment
            {
                Id = 1,
                Name = "Dumbbell",
            };

            await db.ExerciseEquipments.AddAsync(equipment);
            await db.SaveChangesAsync();

            var category = new ExerciseCategory
            {
                Id = 1,
                Name = "Biceps",
            };

            await db.ExerciseCategories.AddAsync(category);
            await db.SaveChangesAsync();

            var inputModel1 = new CreateExerciseInputModel
            {
                Name = "Seated Arnold Press",
                Description = "Keep your back flat against ....",
                EquipmentId = 1,
                CategoryId = 1,
                Difficulty = ExerciseDifficulty.Expert,
                ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/seated-arnold-press-thumb.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=jv31A4Ab4nA",
            };
            await service.CreateExcerciseAsync(inputModel1, user1.Id);

            var inputModel2 = new CreateExerciseInputModel
            {
                Name = "Pull ups",
                Description = "Pull ups description....",
                EquipmentId = 1,
                CategoryId = 1,
                Difficulty = ExerciseDifficulty.Beginner,
                ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/seated-arnold-press-thumb.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=jv31A4Ab4nA",
            };
            await service.CreateExcerciseAsync(inputModel2, user1.Id);

            var result = service.GetExercisesByCategoryId(1);

            Assert.Equal(inputModel1.Name, result.Where(x => x.Id == 1).Select(x => x.Name).FirstOrDefault());
            Assert.Equal(inputModel2.Name, result.Where(x => x.Id == 2).Select(x => x.Name).FirstOrDefault());
        }

        [Fact]
        public async Task GetExerciseByDayOfWeek()
        {
            ApplicationDbContext db = GetDb();

            var exerciseCategoryRepository = new EfDeletableEntityRepository<ExerciseCategory>(db);
            var exerciseEquipmentRepository = new EfDeletableEntityRepository<ExerciseEquipment>(db);
            var exerciseRepository = new EfDeletableEntityRepository<Exercise>(db);
            var userExerciseRepository = new EfDeletableEntityRepository<UserExercise>(db);

            var service = new ExercisesService(exerciseCategoryRepository, exerciseEquipmentRepository, exerciseRepository, userExerciseRepository);

            var user1 = new ApplicationUser
            {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = null,
            };

            await db.Users.AddAsync(user1);
            await db.SaveChangesAsync();

            var user2 = new ApplicationUser
            {
                Id = "y123",
                UserName = "petkata",
                Email = "petar@petrov.bb",
                FirstName = "Petar",
                LastName = "Petrov",
                Profile = new Profile(),
            };

            await db.Users.AddAsync(user2);
            await db.SaveChangesAsync();

            var equipment = new ExerciseEquipment
            {
                Id = 1,
                Name = "Dumbbell",
            };

            await db.ExerciseEquipments.AddAsync(equipment);
            await db.SaveChangesAsync();

            var category = new ExerciseCategory
            {
                Id = 1,
                Name = "Biceps",
            };

            await db.ExerciseCategories.AddAsync(category);
            await db.SaveChangesAsync();

            var inputModel1 = new CreateExerciseInputModel
            {
                Name = "Seated Arnold Press",
                Description = "Keep your back flat against ....",
                EquipmentId = 1,
                CategoryId = 1,
                Difficulty = ExerciseDifficulty.Expert,
                ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/seated-arnold-press-thumb.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=jv31A4Ab4nA",
            };
            await service.CreateExcerciseAsync(inputModel1, user1.Id);

            var inputModel2 = new CreateExerciseInputModel
            {
                Name = "Pull ups",
                Description = "Pull ups description....",
                EquipmentId = 1,
                CategoryId = 1,
                Difficulty = ExerciseDifficulty.Beginner,
                ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/seated-arnold-press-thumb.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=jv31A4Ab4nA",
            };
            await service.CreateExcerciseAsync(inputModel2, user1.Id);

            var inputModel = new AddExerciseInputModel
            {
                Id = 2,
                Repetitions = 10,
                Sets = 5,
                Weight = 20,
                WeekDay = WeekDay.Monday,
            };
            await service.AddExerciseToUserAsync(inputModel, user2.Id);

            var result = service.GetExercisesByDayOfWeek(user2.Id, "Monday");

            var expectedResult = result.Where(x => x.ExerciseId == 2).Select(x => x.Name).FirstOrDefault();

            Assert.Equal(inputModel2.Name, expectedResult);
        }

        [Fact]
        public async Task RemoveExerciseShouldWorkCorrectly()
        {
            ApplicationDbContext db = GetDb();

            var exerciseCategoryRepository = new EfDeletableEntityRepository<ExerciseCategory>(db);
            var exerciseEquipmentRepository = new EfDeletableEntityRepository<ExerciseEquipment>(db);
            var exerciseRepository = new EfDeletableEntityRepository<Exercise>(db);
            var userExerciseRepository = new EfDeletableEntityRepository<UserExercise>(db);

            var service = new ExercisesService(exerciseCategoryRepository, exerciseEquipmentRepository, exerciseRepository, userExerciseRepository);

            var user1 = new ApplicationUser
            {
                Id = "x123",
                UserName = "vankata",
                Email = "ivan@ivan.bb",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Profile = null,
            };

            await db.Users.AddAsync(user1);
            await db.SaveChangesAsync();

            var user2 = new ApplicationUser
            {
                Id = "y123",
                UserName = "petkata",
                Email = "petar@petrov.bb",
                FirstName = "Petar",
                LastName = "Petrov",
                Profile = new Profile(),
            };

            await db.Users.AddAsync(user2);
            await db.SaveChangesAsync();

            var equipment = new ExerciseEquipment
            {
                Id = 1,
                Name = "Dumbbell",
            };

            await db.ExerciseEquipments.AddAsync(equipment);
            await db.SaveChangesAsync();

            var category = new ExerciseCategory
            {
                Id = 1,
                Name = "Biceps",
            };

            await db.ExerciseCategories.AddAsync(category);
            await db.SaveChangesAsync();

            var inputModel1 = new CreateExerciseInputModel
            {
                Name = "Seated Arnold Press",
                Description = "Keep your back flat against ....",
                EquipmentId = 1,
                CategoryId = 1,
                Difficulty = ExerciseDifficulty.Expert,
                ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/seated-arnold-press-thumb.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=jv31A4Ab4nA",
            };
            await service.CreateExcerciseAsync(inputModel1, user1.Id);

            var inputModel2 = new CreateExerciseInputModel
            {
                Name = "Pull ups",
                Description = "Pull ups description....",
                EquipmentId = 1,
                CategoryId = 1,
                Difficulty = ExerciseDifficulty.Beginner,
                ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/seated-arnold-press-thumb.jpg",
                VideoUrl = "https://www.youtube.com/watch?v=jv31A4Ab4nA",
            };
            await service.CreateExcerciseAsync(inputModel2, user1.Id);

            var inputModel = new AddExerciseInputModel
            {
                Id = 2,
                Repetitions = 10,
                Sets = 5,
                Weight = 20,
                WeekDay = WeekDay.Monday,
            };
            await service.AddExerciseToUserAsync(inputModel, user2.Id);

            var doesUserHaveExerciseBeforeDeletion = db.UserExercises.Any(x => x.ExerciseId == 2 && x.User.Id == user2.Id);

            await service.RemoveExerciseAsync(user2.Id, 2);

            var doesUserHaveExerciseAfterDeletion = db.UserExercises.Any(x => x.ExerciseId == 2 && x.User.Id == user2.Id);

            Assert.True(doesUserHaveExerciseBeforeDeletion);
            Assert.False(doesUserHaveExerciseAfterDeletion);
        }
    }
}
