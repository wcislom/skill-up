using Forecaster.Infrastructure.Database;
using Microsoft.EntityFrameworkCore.Storage;
using OpenTelemetry.Trace;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Forecaster.Core;

namespace MigrationService
{
    public class Worker : BackgroundService
    {
        public static string Name = "MigrationService";
        private static readonly ActivitySource s_activitySource = new ActivitySource(Name);

        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider serviceProvider;
        private readonly IHostApplicationLifetime hostApplicationLifetime;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider,
    IHostApplicationLifetime hostApplicationLifetime)
        {
            _logger = logger;
            this.serviceProvider = serviceProvider;
            this.hostApplicationLifetime = hostApplicationLifetime;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            using var activity = s_activitySource.StartActivity("Migrating database", ActivityKind.Client);

            try
            {
                using var scope = serviceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<WeatherForecastDbContext>();

                await EnsureDatabaseAsync(dbContext, cancellationToken);
                await RunMigrationAsync(dbContext, cancellationToken);
                await SeedDataAsync(dbContext, cancellationToken);
            }
            catch (Exception ex)
            {
                activity?.AddException(ex);
                throw;
            }

            hostApplicationLifetime.StopApplication();
        }

        private static async Task EnsureDatabaseAsync(WeatherForecastDbContext dbContext, CancellationToken cancellationToken)
        {
            var dbCreator = dbContext.GetService<IRelationalDatabaseCreator>();

            var strategy = dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                // Create the database if it does not exist.
                // Do this first so there is then a database to start a transaction against.
                if (!await dbCreator.ExistsAsync(cancellationToken))
                {
                    await dbCreator.CreateAsync(cancellationToken);
                }
            });
        }

        private static async Task RunMigrationAsync(WeatherForecastDbContext dbContext, CancellationToken cancellationToken)
        {
            var strategy = dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                // Run migration in a transaction to avoid partial migration if it fails.
                await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
                await dbContext.Database.MigrateAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            });
        }

        private static async Task SeedDataAsync(WeatherForecastDbContext dbContext, CancellationToken cancellationToken)
        {
            WeatherForecast forecast = new(new DateOnly(2025, 1, 1), 4, "Warm, Sunny", null);
            

            var strategy = dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                // Seed the database
                await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
                await dbContext.WeatherForecasts.AddAsync(forecast, cancellationToken);
                await dbContext.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            });
        }
    }
}
