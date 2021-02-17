using Domain.Ads;
using Domain.UserProfiles;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Picture = Domain.Ads.Pictures;

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
