using Forecaster.Core.Repositories;

namespace Forecaster.ApiService
{
    public static class Endpoints
    {
        public static void MapForecasterEndpoints(this WebApplication app)
        {
            app.MapGet("/weatherforecast", async (IWeatherForecastRepository repository) =>
            {
               var forecasts = await repository.GetAllForecasts();
                return forecasts;
            })
            .WithName("GetWeatherForecast");
        }
    }
}
