using Forecaster.Core;
using Microsoft.EntityFrameworkCore;

namespace Forecaster.ApiService.Database
{
    public class WeatherForecastDbContext : DbContext
    {
        public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options)
            : base(options)
        {
        }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
