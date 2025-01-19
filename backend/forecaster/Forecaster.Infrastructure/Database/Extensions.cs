using Forecaster.Core.Repositories;
using Forecaster.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Forecaster.Infrastructure.Database
{
    public static class Extensions
    {
        public static void AddForecasterDatabase(this IHostApplicationBuilder builder)
        {
            builder.AddSqlServerDbContext<WeatherForecastDbContext>(connectionName: "forecaster", null, options =>
            {
                options.UseSqlServer(x => x.MigrationsAssembly("Forecaster.Infrastructure"));
            });

            builder.Services.AddTransient<IWeatherForecastRepository, WeatherForecastRepository>();
        }
    }
}
