using Forecaster.ApiService.Options;
using Forecaster.Core.Repositories;
using Microsoft.Extensions.Options;

namespace Forecaster.ApiService
{
    public static class Endpoints
    {
        public static WebApplication MapForecasterEndpoints(this WebApplication app)
        {
            app.MapGet("/weatherforecast", async (IWeatherForecastRepository repository, CancellationToken cancelationToken) =>
            {
               var forecasts = await repository.GetAllForecasts(cancelationToken);
                return forecasts;
            })
            .WithName("GetWeatherForecast");

            return app;
        }


        public static WebApplication MapGeneralEndpoints(this WebApplication app)
        {
            app.MapGet("/options", (IOptions<SomeOptions> options,
                IOptionsSnapshot<SomeOptions> snaphshot,
                IOptionsMonitor<SomeOptions> monitor) =>
            {
                return Results.Ok(new
                {
                    Options = options.Value,
                    Snapshot = snaphshot.Value,
                    Monitor = monitor.CurrentValue
                });
            });

            return app;
        }
    }
}
