1. Add migration 
dotnet ef migrations add RenamesIdColumn  -o Database\Migrations --project ../Forecaster.Infrastructure

2. Apply migration
dotnet ef database update

Above needs correct connection string specified

3. To properly run migrations you need to specify migration project in options:
	  builder.AddSqlServerDbContext<WeatherForecastDbContext>(connectionName: "forecaster", null, options =>
            {
                options.UseSqlServer(x => x.MigrationsAssembly("Forecaster.Infrastructure"));
            });
    Without that the exception is thrown about pending migration (no migration is also pending migration).

4. EntityFramework.Design packages are development time only packages. They are not needed in runtime and they are not transitive.

6. Remove migration from db
    dotnet ef migrations remove --project ../Forecaster.Infrastructure
