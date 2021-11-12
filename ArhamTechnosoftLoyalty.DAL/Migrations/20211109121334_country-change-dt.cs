using Microsoft.EntityFrameworkCore.Migrations;

namespace ArhamTechnosoftLoyalty.DAL.Migrations
{
    public partial class countrychangedt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "latitude",
                table: "State",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "longitude",
                table: "State",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "latitude",
                table: "Country",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "longitude",
                table: "Country",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "latitude",
                table: "State");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "State");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "Country");
        }
    }
}
