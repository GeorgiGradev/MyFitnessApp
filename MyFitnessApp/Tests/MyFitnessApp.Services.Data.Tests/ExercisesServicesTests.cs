namespace MyFitnessApp.Services.Data.Tests
{
    using Moq;
    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;

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
    }
}
