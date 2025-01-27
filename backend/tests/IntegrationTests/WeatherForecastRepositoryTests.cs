using Forecaster.Core;
using Forecaster.Core.Entities;
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
            using(var transaction = _fixture.DbContext.Database.BeginTransaction())
            {
                _fixture.DbContext.WeatherForecasts.Add(new WeatherForecast(0, new DateOnly(2025,1,10), 20, "Warm"));
                _fixture.DbContext.SaveChanges();
                transaction.Commit();
            }
        }

        [Fact]
        public async Task GetAllForecasts_ReturnsAllForecasts()
        {
            // act
            var forecasts = await _repository.GetAllForecasts(CancellationToken.None);

            // assert
            Assert.NotEmpty(forecasts);
        }

        [Fact]
        public async Task DbContext_ChangeDetectorPlayground()
        {
            var dbContext = _fixture.DbContext;
           
            var weatherForecast = dbContext.WeatherForecasts.First();

            weatherForecast.Summary = "Changed summary";

            dbContext.ChangeTracker.DetectChanges();

            var state = dbContext.ChangeTracker.Entries().First().State;

            dbContext.Attach(weatherForecast);

        }
    }
}
