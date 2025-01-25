namespace Forecaster.Core.Entities
{
    public class WeatherForecast
    {
        public WeatherForecast(int id, DateOnly date, int temperatureC, string? summary)
        {
            Id = id;
            Date = date;
            TemperatureC = temperatureC;
            Summary = summary;
        }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public int Id { get; }
        public DateOnly Date { get; }
        public int TemperatureC { get; }
        public string? Summary { get; set; }
    }
}
