using Forecaster.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.Fixtures
{
    public class DbContextFixture : IDisposable
    {
        private readonly WeatherForecastDbContext _dbContext;

        public DbContextFixture() 
        {
            _dbContext = new WeatherForecastDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<WeatherForecastDbContext>()
            {
                
            });
        }

        public WeatherForecastDbContext DbContext => _dbContext;

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
