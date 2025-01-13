using Forecaster.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forecaster.ApiService.Database.Configurations
{
    public class WeatherForecastTypeConfiguration : IEntityTypeConfiguration<WeatherForecast>
    {
        public void Configure(EntityTypeBuilder<WeatherForecast> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.TemperatureC).IsRequired();
            builder.Property(e => e.Summary).IsRequired();
        }
    }
}
