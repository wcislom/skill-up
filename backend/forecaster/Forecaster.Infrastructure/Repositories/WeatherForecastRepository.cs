using Forecaster.Core;
using Forecaster.Core.Repositories;
using Forecaster.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Forecaster.Infrastructure.Repositories
{
    internal class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly WeatherForecastDbContext _dbContext;
        public WeatherForecastRepository(WeatherForecastDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<WeatherForecast>> GetAllForecasts(CancellationToken cancellationToken)
        {
            return await _dbContext.WeatherForecasts.ToListAsync(cancellationToken);
        }
    }
}
