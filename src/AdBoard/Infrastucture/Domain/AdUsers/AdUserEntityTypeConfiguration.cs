using Domain.AdUsers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastucture.Domain.AdUsers
{
    public class AdUserEntityTypeConfiguration : IEntityTypeConfiguration<AdUser>
    {
        public void Configure(EntityTypeBuilder<AdUser> builder)
        {
            builder.ToTable("AdUsers");

            builder.HasKey(b => b.Id);
            builder.OwnsOne(x => x.Name, y =>
            {
                y.Property(x => x.FirstName);
                y.Property(x => x.SecondName);
            });

            builder.OwnsOne(x => x.ContactInformation, y =>
            {
                y.Property(x => x.PhoneNumber);
                y.Property(x => x.Telegram);
            });
        }
    }
}
