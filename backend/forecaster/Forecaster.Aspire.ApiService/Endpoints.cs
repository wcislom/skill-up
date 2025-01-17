using Forecaster.Core;
using System.Reflection.Metadata.Ecma335;

namespace Forecaster.ApiService
{
    public static class Endpoints
    {
        public static void MapForecasterEndpoints(this WebApplication app)
        {
            app.MapGet("/weatherforecast", () =>
            {
                string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    (
                        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        Random.Shared.Next(-20, 55),
                        summaries[Random.Shared.Next(summaries.Length)],
                        index
                    ))
                    .ToArray();
                return forecast;
            })
.WithName("GetWeatherForecast");
        }

        
    }
}
