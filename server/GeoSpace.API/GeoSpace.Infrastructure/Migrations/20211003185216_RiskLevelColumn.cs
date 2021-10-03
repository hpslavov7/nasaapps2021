using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoSpace.Infrastructure.Migrations
{
    public partial class RiskLevelColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeneralRiskLevel",
                table: "Landslides",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeneralRiskLevel",
                table: "Landslides");
        }
    }
}
