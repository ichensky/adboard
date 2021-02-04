using Domain.UserProfiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastucture.Domain.UserProfiles
{
    public class UserProfileEntityTypeConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("UserProfiles");

            builder.HasKey(b => b.Id);

            builder.OwnsOne(x => x.Name, y =>
            {
                y.Property(x => x.FirstName).HasColumnName(nameof(UserProfile.Name.FirstName));
                y.Property(x => x.LastName).HasColumnName(nameof(UserProfile.Name.LastName));
            });
            builder.OwnsOne(x => x.ContactInformation, y =>
            {
                y.Property(x => x.PhoneNumber).HasColumnName(nameof(UserProfile.ContactInformation.PhoneNumber));
                y.Property(x => x.Telegram).HasColumnName(nameof(UserProfile.ContactInformation.Telegram));
                y.Property(x => x.Instagram).HasColumnName(nameof(UserProfile.ContactInformation.Instagram));
            });

            builder.OwnsOne(x => x.Picture, y =>
            {
                y.Property(x => x.Value).HasColumnName(nameof(UserProfile.Picture));
            });
        }
    }
}
