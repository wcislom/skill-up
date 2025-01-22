using Forecaster.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace IntegrationTests.Fixtures
{
    public class DbContextFixture : IDisposable
    {
        private readonly WeatherForecastDbContext _dbContext;
        private const string ConnectionString = "put-connection-string-here";

        public DbContextFixture() 
        {

            var config = new ConfigurationBuilder()
            .AddUserSecrets(typeof(DbContextFixture).Assembly)
            .Build();

            // TODO: get password from secret manager

            _dbContext = new WeatherForecastDbContext(new DbContextOptionsBuilder<WeatherForecastDbContext>()
                .UseSqlServer(ConnectionString, options =>
                {
                })
                .Options);
        }

        public WeatherForecastDbContext DbContext => _dbContext;

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
