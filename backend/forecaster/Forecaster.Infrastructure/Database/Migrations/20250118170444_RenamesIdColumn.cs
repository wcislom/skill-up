using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forecaster.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class RenamesIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WeatherForecasts",
                newName: "WeatherForecastId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WeatherForecastId",
                table: "WeatherForecasts",
                newName: "Id");
        }
    }
}
