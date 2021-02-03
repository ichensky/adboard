using Domain.Ads.Ad;
using Domain.Ads.Ad.Pictures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Domain.Ads
{
    public class AdEntityTypeConfiguration : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder.ToTable("Ads");

            builder.HasKey(b => b.Id);
            builder.Property(x => x.CreationDate).HasColumnName(nameof(Ad.CreationDate));
            builder.Property(x => x.DeleteDate).HasColumnName(nameof(Ad.DeleteDate));
            builder.Property(x => x.UpdateDate).HasColumnName(nameof(Ad.UpdateDate));

            builder.OwnsOne(x => x.Description, y =>
            {
                y.Property(x => x!.Value).HasColumnName(nameof(Ad.Description));
            });
            builder.OwnsOne(x => x.Keywords, y =>
            {
                y.Property(x => x!.Value).HasColumnName(nameof(Ad.Keywords));
            });
            builder.OwnsOne(x => x.Name, y =>
            {
                y.Property(x => x!.Value).HasColumnName(nameof(Ad.Name));
            });
            builder.OwnsOne(x => x.YoutubeUrl, y =>
            {
                y.Property(x => x!.Value).HasColumnName(nameof(Ad.YoutubeUrl));
            });

            builder.OwnsOne(x => x.Publish, y =>
            {
                y.Property(x => x.PublishDate).HasColumnName(nameof(Ad.Publish.PublishDate));
                y.Property(x => x.RejectionCount).HasColumnName(nameof(Ad.Publish.RejectionCount));
                y.Property(x => x.Status).HasColumnName(nameof(Ad.Publish.Status));
            });

            builder.OwnsMany(x => x.Pictures, y =>
            {
                y.HasKey(x => x.Id);
                y.Property(x => x.CreationDate).HasColumnName(nameof(Picture.CreationDate));
                y.Property(x => x.GoogleId).HasColumnName(nameof(Picture.GoogleId));
                y.Property(x => x.Order).HasColumnName(nameof(Picture.Order));

                builder.OwnsOne(x => x.Description, y =>
                {
                    y.Property(x => x!.Value).HasColumnName(nameof(Picture.Description));
                });

                y.WithOwner().HasForeignKey("UserProfilesId");
            });
        }
    }
}
