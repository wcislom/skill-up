using Forecaster.ApiService.Options;
using Forecaster.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics.Metrics;

namespace Forecaster.ApiService
{
    public static class Endpoints
    {
        public static Meter meter = new Meter("Forecaster.Meter");
        public static Counter<int> CallsCounter = meter.CreateCounter<int>("Forecaster.Meter.RequestsCount");
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
                IOptionsMonitor<SomeOptions> monitor,
                [FromServices] ILoggerFactory loggerFactory,
                [FromServices]  SomeOptions optionsFromDC
               ) =>
            {
                CallsCounter.Add(1);
                var logger = loggerFactory.CreateLogger("OptionsEndpoint");
                logger.LogWarning("This is some warning from {endpoint}", "options");
                using var scope =  logger.BeginScope<SomeOptions>(new SomeOptions());
                logger.LogInformation("I am in the scope");
                return Results.Ok(new
                {
                    Options = options.Value,
                    Snapshot = snaphshot.Value,
                    Monitor = monitor.CurrentValue,
                    OtionsFromDC = optionsFromDC
                });
            });

            return app;
        }
    }
}
