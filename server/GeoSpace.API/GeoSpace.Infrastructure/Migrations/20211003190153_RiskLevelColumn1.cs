using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoSpace.Infrastructure.Migrations
{
    public partial class RiskLevelColumn1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistanceFromFaults",
                table: "Landslides",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DistanceFromRivers",
                table: "Landslides",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Elevation",
                table: "Landslides",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GeologyPermeability",
                table: "Landslides",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LandUse",
                table: "Landslides",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "SlopeAngle",
                table: "Landslides",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "SlopeAspect",
                table: "Landslides",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistanceFromFaults",
                table: "Landslides");

            migrationBuilder.DropColumn(
                name: "DistanceFromRivers",
                table: "Landslides");

            migrationBuilder.DropColumn(
                name: "Elevation",
                table: "Landslides");

            migrationBuilder.DropColumn(
                name: "GeologyPermeability",
                table: "Landslides");

            migrationBuilder.DropColumn(
                name: "LandUse",
                table: "Landslides");

            migrationBuilder.DropColumn(
                name: "SlopeAngle",
                table: "Landslides");

            migrationBuilder.DropColumn(
                name: "SlopeAspect",
                table: "Landslides");
        }
    }
}
