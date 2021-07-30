namespace MyFitnessApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyFitnessApp.Data.Models;

    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> profile)
        {
            profile
                .HasOne(x => x.AddedByUser)
                .WithOne(x => x.Profile)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
