using Forecaster.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.Common;

namespace IntegrationTests.Fixtures
{
    public class DbContextFixture : IDisposable
    {
        private readonly ForecasterDbContext _dbContext;

        public DbContextFixture() 
        {

            var config = new ConfigurationBuilder()
            .AddUserSecrets(typeof(DbContextFixture).Assembly)
            .Build();

            DbConnectionStringBuilder builder = new DbConnectionStringBuilder
            {
                { "Server", "127.0.0.1" },
                { "Database", Guid.NewGuid().ToString() },
                { "User Id", config.GetValue<string>("Secrets:testUserLogin")  },
                { "Password", config.GetValue<string>("Secrets:testUserPassword") },
                { "TrustServerCertificate", "True" }
            };

            var connectionString = builder.ConnectionString;

            _dbContext = new ForecasterDbContext(new DbContextOptionsBuilder<ForecasterDbContext>()
                .UseSqlServer(connectionString)
                .Options);

            _dbContext.Database.EnsureCreated();
        }

        public ForecasterDbContext DbContext => _dbContext;

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}
