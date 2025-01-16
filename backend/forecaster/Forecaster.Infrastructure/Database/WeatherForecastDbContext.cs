using Forecaster.Core;
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
        }

         public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
