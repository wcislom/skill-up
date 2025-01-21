using Forecaster.Core.Repositories;
using Forecaster.Infrastructure.Repositories;
using IntegrationTests.Fixtures;

namespace IntegrationTests
{
    public class WeatherForecastRepositoryTests : IClassFixture<DbContextFixture>
    {
        private DbContextFixture _fixture;
        private IWeatherForecastRepository _repository;

        public WeatherForecastRepositoryTests(DbContextFixture fixture)
        {
            _fixture = fixture;
            _repository = new WeatherForecastRepository(_fixture.DbContext);
        }
    }
}
