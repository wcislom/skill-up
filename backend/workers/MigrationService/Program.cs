using Forecaster.Infrastructure.Database;
using MigrationService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.AddServiceDefaults();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.Name));

builder.AddForecasterDatabase();
var host = builder.Build();
host.Run();
