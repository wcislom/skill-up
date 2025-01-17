namespace Forecaster.Core
{

    public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary, int? Id)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
