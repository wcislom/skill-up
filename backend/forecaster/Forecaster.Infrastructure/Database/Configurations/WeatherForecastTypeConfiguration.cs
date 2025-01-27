using Forecaster.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forecaster.Infrastructure.Database.Configurations
{
    public class WeatherForecastTypeConfiguration : IEntityTypeConfiguration<WeatherForecast>
    {
        public void Configure(EntityTypeBuilder<WeatherForecast> builder)
        {
            builder.ToTable("WeatherForecast", Schemas.Weather);
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("WeatherForecastId");
            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.TemperatureC).IsRequired();
            builder.Property(e => e.Summary).IsRequired();
        }
    }
}
