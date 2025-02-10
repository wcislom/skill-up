using Forecaster.Core.Entities;
using Forecaster.Core.Entities.VideoGames;
using Microsoft.EntityFrameworkCore;

namespace Forecaster.Infrastructure.Database
{
    public class ForecasterDbContext : DbContext
    {
        public ForecasterDbContext(DbContextOptions<ForecasterDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ForecasterDbContext).Assembly);

            //modelBuilder.Entity<WeatherForecast>().HasData(
            //    new WeatherForecast(
            //        1,
            //       new DateOnly(2025, 5, 1),
            //       25,
            //       "Hot"
            //    ),
            //     new WeatherForecast(
            //       2,
            //       new DateOnly(2025, 5, 2),
            //       20,
            //       "Warm"
            //    ),
            //    new WeatherForecast(
            //        3,
            //       new DateOnly(2025, 5, 3),
            //       15,
            //       "Chill"
            //    )
            //);
        }

         public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public DbSet<VideoGame> VideoGame { get; set; }

        public DbSet<VideoGameDetails> VideoGameDetails { get; set; }
    }
}
