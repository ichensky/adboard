using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Domain.Users
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("AspNetUsers");

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
