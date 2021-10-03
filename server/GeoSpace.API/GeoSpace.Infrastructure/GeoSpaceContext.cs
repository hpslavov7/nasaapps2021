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
            optionsBuilder.UseSqlServer(@"Data Source=tcp:rumennasa.database.windows.net,1433;Initial Catalog=API_db;User Id=rumen@rumennasa;Password=$Blink185");
        }
        public DbSet<ActiveRainFall> ActiveRainFalls { get; set; }
        public DbSet<ActiveEarthQuake> ActiveEarthQuakes { get; set; }
        public DbSet<Landslide> LandSlides { get; set; }
        public DbSet<UserReport> UserReports { get; set; }
    }
}
