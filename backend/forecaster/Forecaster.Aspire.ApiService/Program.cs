using Forecaster.ApiService;
using Forecaster.ApiService.Options;
using Forecaster.Infrastructure.Database;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();
builder.Services.AddOpenTelemetry().WithMetrics(b => b.AddMeter("Forecaster.Meter"));
builder.Configuration.AddDbConfigurationSample();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.AddForecasterDatabase();

//var section = builder.Configuration.GetSection(SomeOptions.SectionName);
//builder.Services.AddOptions<SomeOptions>()
//    .Bind(section)
//    .ValidateDataAnnotations()
//    .ValidateOnStart();

// equivalent
builder.Services.AddCallsMeter();
builder.Services.AddOptions<SomeOptions>()
    .BindConfiguration(SomeOptions.SectionName)
    .Configure(options =>
    {
        // Overwrites values from configuration
        options.RetryCount = 8;
    })
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddSingleton<IConfigureOptions<SomeOptions>, SomeOptions>()
    .AddSingleton<IValidateOptions<SomeOptions>, SomeOptions>()
    .AddScoped((sp) => sp.GetRequiredService<IOptionsSnapshot<SomeOptions>>().Value);

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapForecasterEndpoints()
    .MapGeneralEndpoints();

app.MapDefaultEndpoints();

app.Run();
