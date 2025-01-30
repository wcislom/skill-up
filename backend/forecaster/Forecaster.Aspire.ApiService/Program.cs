using Forecaster.ApiService;
using Forecaster.ApiService.Options;
using Forecaster.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();
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

builder.Services.AddOptions<SomeOptions>()
    .BindConfiguration(SomeOptions.SectionName)
    .ValidateDataAnnotations()
    .ValidateOnStart();

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
