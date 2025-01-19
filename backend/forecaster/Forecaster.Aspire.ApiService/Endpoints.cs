using Forecaster.Core.Repositories;

namespace Forecaster.ApiService
{
    public static class Endpoints
    {
        public static void MapForecasterEndpoints(this WebApplication app)
        {
            app.MapGet("/weatherforecast", async (IWeatherForecastRepository repository, CancellationToken cancelationToken) =>
            {
               var forecasts = await repository.GetAllForecasts(cancelationToken);
                return forecasts;
            })
            .WithName("GetWeatherForecast");
        }
    }
}
