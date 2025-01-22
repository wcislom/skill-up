var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var sql = builder.AddSqlServer("sql", port: 1433)
    .WithLifetime(ContainerLifetime.Persistent)
    .WithDataVolume();

var db = sql.AddDatabase("forecaster");

var apiService = builder.AddProject<Projects.Forecaster_ApiService>("apiservice").WithReference(db).WaitFor(db);

builder.AddProject<Projects.MigrationService>("migration-worker").WithReference(db).WaitFor(db);

builder.AddProject<Projects.Forecaster_Aspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
