using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoSpace.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActiveEarthQuakes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EpicentralDistanceKm = table.Column<int>(nullable: false),
                    Magnitude = table.Column<int>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Lattitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveEarthQuakes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActiveRainFalls",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Rate = table.Column<double>(nullable: false),
                    Hours = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Lattitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveRainFalls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Landslides",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LandslideMovementType = table.Column<string>(nullable: true),
                    LandslideMaterialType = table.Column<string>(nullable: true),
                    RainfallCorrelation = table.Column<string>(nullable: true),
                    LandslideForcesDetails = table.Column<string>(nullable: true),
                    LatitudeCenter = table.Column<decimal>(nullable: false),
                    LongitudeCenter = table.Column<decimal>(nullable: false),
                    Width = table.Column<decimal>(nullable: false),
                    Length = table.Column<decimal>(nullable: false),
                    Depth = table.Column<decimal>(nullable: false),
                    SlopeSteepness = table.Column<decimal>(nullable: false),
                    LinearMovement = table.Column<decimal>(nullable: false),
                    Volume = table.Column<decimal>(nullable: false),
                    GovernmentId = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    ReportedBy = table.Column<string>(nullable: true),
                    Damages = table.Column<string>(nullable: true),
                    Casualities = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landslides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserReport",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Longitude = table.Column<decimal>(nullable: false),
                    Latitude = table.Column<decimal>(nullable: false),
                    NearbyCity = table.Column<string>(nullable: true),
                    ReporterName = table.Column<string>(nullable: true),
                    ReporterContact = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReport", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveEarthQuakes");

            migrationBuilder.DropTable(
                name: "ActiveRainFalls");

            migrationBuilder.DropTable(
                name: "Landslides");

            migrationBuilder.DropTable(
                name: "UserReport");
        }
    }
}
