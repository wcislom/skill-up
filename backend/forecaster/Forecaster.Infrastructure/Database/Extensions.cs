using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecaster.Infrastructure.Database
{
    public static class Extensions
    {
        public static void AddForecasterDatabase(this IHostApplicationBuilder builder)
        {
            builder.AddSqlServerDbContext<WeatherForecastDbContext>(connectionName: "forecaster");

        }
    }
}
