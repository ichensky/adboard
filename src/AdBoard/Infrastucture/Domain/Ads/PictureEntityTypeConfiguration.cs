using Domain.Ads.Pictures;
using Infrastucture.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Domain.Ads
{
    public class PictureEntityTypeConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.ToTable("Pictures");

            builder.Property(x => x.Id).HasConversion(new TypedIdValuesObjectConverter());
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreationDate).HasColumnName(nameof(Picture.CreationDate));
            builder.Property(x => x.GoogleId).HasColumnName(nameof(Picture.GoogleId));
            builder.Property(x => x.Order).HasColumnName(nameof(Picture.Order));

            builder.OwnsOne(x => x.Description, y =>
            {
                y.Property(x => x.Value).HasColumnName(nameof(Picture.Description));
            });

            builder.HasOne(x => x.Ad).WithMany(x => x.Pictures).HasForeignKey("AdsId");
        }
    }
}
