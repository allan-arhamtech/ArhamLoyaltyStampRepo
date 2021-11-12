using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ArhamTechnosoftLoyalty.DAL.Migrations
{
    public partial class citynew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "City",
               columns: table => new
               {
                   id = table.Column<int>(type: "integer", nullable: false)
                       .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                   state_id = table.Column<int>(type: "integer", nullable: false),
                   state_code = table.Column<string>(type: "text", nullable: true),
                   country_id = table.Column<int>(type: "integer", nullable: false),
                   country_code = table.Column<string>(type: "text", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_City", x => x.id);
               });
            migrationBuilder.AddColumn<float>(
                name: "latitude",
                table: "City",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "longitude",
                table: "City",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "latitude",
                table: "City");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "City");
        }
    }
}
