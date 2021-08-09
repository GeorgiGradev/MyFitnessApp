namespace MyFitnessApp.Services.Data.Tests
{
    using Moq;
    using MyFitnessApp.Data.Common.Repositories;
    using MyFitnessApp.Data.Models;
    using MyFitnessApp.Services.Data.Profile;

    public class CommentsServicesTests : BaseServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<Comment>> commentRepository;
        private readonly Mock<IProfilesService> profilesService;

        public CommentsServicesTests()
        {
            this.commentRepository = new Mock<IDeletableEntityRepository<Comment>>();
            this.profilesService = new Mock<IProfilesService>();
        }
    }
}
