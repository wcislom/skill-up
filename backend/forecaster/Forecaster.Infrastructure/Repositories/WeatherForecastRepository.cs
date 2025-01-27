using Forecaster.Core.Entities;
using Forecaster.Core.Repositories;
using Forecaster.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Forecaster.Infrastructure.Repositories
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly ForecasterDbContext _dbContext;
        public WeatherForecastRepository(ForecasterDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<WeatherForecast>> GetAllForecasts(CancellationToken cancellationToken)
        {
            return await _dbContext.WeatherForecasts.ToListAsync(cancellationToken);
        }
    }
}
