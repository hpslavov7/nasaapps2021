using GeoSpace.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace GeoSpace.Infrastructure
{
    public class GeoSpaceContext : DbContext
    {
        public GeoSpaceContext(DbContextOptions<GeoSpaceContext> opt)
    : base(opt)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.;database=GEOSpaceDN;Trusted_Connection=true");
        }
        public DbSet<ActiveRainFall> ActiveRainFalls { get; set; }
        public DbSet<ActiveEarthQuake> ActiveEarthQuakes { get; set; }
        public DbSet<Landslide> LandSlides { get; set; }
        public DbSet<UserReport> UserReports { get; set; }
    }
}
