1. Add migration 
dotnet ef migrations add InitialCreate -o Database\Migrations

2. Apply migration
dotnet ef database update

Above needs correct connection string specified