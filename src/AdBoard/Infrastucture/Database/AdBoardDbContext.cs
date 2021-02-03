using Domain.Ads.Ad;
using Domain.UserProfiles;
using Infrastucture.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Picture = Domain.Ads.Ad.Pictures.Picture;

namespace Infrastucture.Database
{
    public class AdBoardDbContext : IdentityDbContext
    {
        public DbSet<Ad> Ads => Set<Ad>();

        public DbSet<UserProfile> UserProfiles => Set<UserProfile>();

        public DbSet<Picture> Pictures => Set<Picture>();

        public AdBoardDbContext(DbContextOptions<AdBoardDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdBoardDbContext).Assembly);

        }
    }
}
