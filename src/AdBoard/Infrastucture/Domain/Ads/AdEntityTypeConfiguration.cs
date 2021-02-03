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
            builder.Property(x => x.CreationDate);
            builder.Property(x => x.DeleteDate);
            builder.Property(x => x.UpdateDate);

            //builder.OwnsOne(x => x.Id, y =>
            //{
            //    y.Property(x => x!.Value).HasColumnName(nameof(Ad.Id));
            //});
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
                y.Property(x => x.PublishDate);
                y.Property(x => x.RejectionCount);
                y.Property(x => x.Status);
            });

            builder.OwnsMany(x => x.Pictures, y =>
            {
                y.HasKey(x => x.Id);
                y.Property(x => x.CreationDate);
                y.Property(x => x.GoogleId);
                y.Property(x => x.Order);

                //builder.OwnsOne(x => x.Id, y =>
                //{
                //    y.Property(x => x!.Value).HasColumnName(nameof(Picture.Id));
                //});
                builder.OwnsOne(x => x.Description, y =>
                {
                    y.Property(x => x!.Value).HasColumnName(nameof(Picture.Description));
                });

                y.WithOwner().HasForeignKey("AdUsersId");
            });
        }
    }
}
