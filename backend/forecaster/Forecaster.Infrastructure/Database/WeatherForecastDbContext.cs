using Forecaster.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forecaster.Infrastructure.Database
{
    public class WeatherForecastDbContext : DbContext
    {
        public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WeatherForecastDbContext).Assembly);

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
    }
}
