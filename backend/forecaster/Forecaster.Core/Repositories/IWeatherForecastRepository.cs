namespace Forecaster.Core.Repositories
{
    public interface IWeatherForecastRepository
    {
        IEnumerable<WeatherForecast> GetAllForecasts();
    }
}
