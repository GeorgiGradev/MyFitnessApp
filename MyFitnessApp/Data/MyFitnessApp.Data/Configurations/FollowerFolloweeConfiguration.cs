namespace MyFitnessApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyFitnessApp.Data.Models;

    public class FollowerFolloweeConfiguration : IEntityTypeConfiguration<FollowerFollowee>
    {
        public void Configure(EntityTypeBuilder<FollowerFollowee> followerFollowee)
        {
            followerFollowee
                .HasOne(x => x.Followee)
                .WithMany(x => x.Followees)
                .HasForeignKey(x => x.FolloweeId)
                .OnDelete(DeleteBehavior.Restrict);

            followerFollowee
                .HasOne(x => x.Follower)
                .WithMany(x => x.Followers)
                .HasForeignKey(x => x.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
