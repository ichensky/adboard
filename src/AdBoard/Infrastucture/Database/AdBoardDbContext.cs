using Domain.Ads.Ad;
using Domain.Ads.Ad.Pictures;
using Domain.AdUsers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Database
{
    public class AdBoardDbContext : IdentityDbContext
    {
        public DbSet<Ad>? Ads { get; set; }

        public DbSet<AdUser>? AdBoardUsers { get; set; }

        public DbSet<Picture>? Pictures { get; set; }

        public AdBoardDbContext(DbContextOptions<AdBoardDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdBoardDbContext).Assembly);
           
        }
    }
}
