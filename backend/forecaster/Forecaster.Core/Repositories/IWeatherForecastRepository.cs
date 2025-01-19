namespace Forecaster.Core.Repositories
{
    public interface IWeatherForecastRepository
    {
        Task<IEnumerable<WeatherForecast>> GetAllForecasts(CancellationToken cancellation);
    }
}
