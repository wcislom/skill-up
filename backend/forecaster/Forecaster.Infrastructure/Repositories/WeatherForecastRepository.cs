using Forecaster.Core;
using Forecaster.Core.Repositories;
using Forecaster.Infrastructure.Database;

namespace Forecaster.Infrastructure.Repositories
{
    internal class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly WeatherForecastDbContext _dbContext;
        public WeatherForecastRepository(WeatherForecastDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<WeatherForecast> GetAllForecasts()
        {
            return _dbContext.WeatherForecasts.ToList();
        }
    }
}
